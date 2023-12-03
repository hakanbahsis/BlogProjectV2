using AutoMapper;
using Business.Extensions;
using Business.Services.ArticleService.Abstract;
using Business.Services.CategoryService.Abstract;
using Entity.DTOs.Articles;
using Entity.DTOs.Categories;
using Entity.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using WebAPP.ResultMessages;

namespace WebAPP.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    private readonly IValidator<Category> _validator;
    private readonly IToastNotification _toast;

    public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper, IToastNotification toast)
    {
        _categoryService = categoryService;
        _validator = validator;
        _mapper = mapper;
        _toast = toast;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategoriesNonDeleted();
        return View(categories);
    }
    [HttpGet]
    public async Task<IActionResult> DeletedCategories()
    {
        var categories = await _categoryService.GetAllCategoriesDeleted();
        return View(categories);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
    {
        var map = _mapper.Map<Category>(categoryAddDto);
        var result = await _validator.ValidateAsync(map);
        if (result.IsValid)
        {
            await _categoryService.CreateCategoryAsync(categoryAddDto);
            _toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        else
        {
            _toast.AddErrorToastMessage("İşlem Başarısız.", new ToastrOptions { Title = "Hata" });
            result.AddToModelState(this.ModelState);;
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
    {
        var map=_mapper.Map<Category>(categoryAddDto);
        var result=await _validator.ValidateAsync(map);
        if (result.IsValid)
        {
            await _categoryService.CreateCategoryAsync(categoryAddDto);
            _toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "Başarı" });
            return Json(Messages.Category.Add(categoryAddDto.Name));
        }
        else
        {
            _toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "Başarısız" });
            return Json(result.Errors.First().ErrorMessage);
        }
        
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid categoryId)
    {
        var category=await _categoryService.GetCategoryByGuid(categoryId);
        
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
    {
        var map=_mapper.Map<Category>(categoryUpdateDto);
        var result=await _validator.ValidateAsync(map);
        if (result.IsValid)
        {
            var name=await _categoryService.UpdateCategoryAsync(categoryUpdateDto);
            _toast.AddSuccessToastMessage(Messages.Category.Update(categoryUpdateDto.Name), new ToastrOptions { Title = "Başarı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        else
        {
            _toast.AddErrorToastMessage("İşlem Başarısız.", new ToastrOptions { Title = "Hata" });
            result.AddToModelState(this.ModelState); ;
            return View();
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid categoryId)
    {
        var name=await _categoryService.SafeDeleteCategoryAsync(categoryId);
        _toast.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions { Title = "Başarı" });
        return RedirectToAction("Index", "Category", new { Area = "Admin" });
    }

    [HttpGet]
    public async Task<IActionResult> UndoDelete(Guid categoryId)
    {
        var name=await _categoryService.UndoDeletedCategoryAsync(categoryId);
        _toast.AddSuccessToastMessage(Messages.Category.UndoDelete(name), new ToastrOptions { Title = "Başarı" });
        return RedirectToAction("Index", "Category", new { Area = "Admin" });
    }
}
