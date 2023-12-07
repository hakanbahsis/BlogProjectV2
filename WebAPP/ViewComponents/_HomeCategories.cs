using Business.Services.CategoryService.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPP.ViewComponents;

public class _HomeCategories:ViewComponent
{
    private readonly ICategoryService _categoryService;

    public _HomeCategories(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryService.GetAllCategoriesNonDeletedTake24();
        return View(categories);
    }
}
