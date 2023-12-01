using AutoMapper;
using Business.Extensions;
using Business.Services.CategoryService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.DTOs.Categories;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CategoryService.Concrete;
public class CategoryManager : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ClaimsPrincipal _user;

    public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _user = _contextAccessor.HttpContext.User; 
    }

    public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
    {
        var userEmail = _user.GetLoggedInEmail();
        Category category = new(categoryAddDto.Name,userEmail);
        await _unitOfWork.GetRepository<Category>().AddAsync(category);
        await _unitOfWork.SaveAsync();

       
    }

    public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
    {
        var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
        var map=_mapper.Map<List<CategoryDto>>(categories);
        return map;
    }

    public async Task<CategoryUpdateDto> GetCategoryByGuid(Guid id)
    {
        var category=await _unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
        var map=_mapper.Map<CategoryUpdateDto>(category);
        return map;
    }

    public async Task<string> SafeDeleteCategoryAsync(Guid categoryId)
    {
        var userEmail = _user.GetLoggedInEmail();
        var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
        category.IsDeleted = true;
        category.DeletedDate = DateTime.Now;
        category.DeletedBy = userEmail;
        await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
        await _unitOfWork.SaveAsync();
        return category.Name;
    }

    public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
    {
        var userEmail=_user.GetLoggedInEmail();
        var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.Id == categoryUpdateDto.Id);
        category.Name = categoryUpdateDto.Name;
        category.ModifiedBy = userEmail;
        category.ModifiedDate=DateTime.Now;

        await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
        await _unitOfWork.SaveAsync();

        return category.Name;
    }
}
