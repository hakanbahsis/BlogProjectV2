using Entity.DTOs.Categories;
using Entity.Entities;

namespace Business.Services.CategoryService.Abstract;
public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
    Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
    Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryAddDto);
    Task<CategoryUpdateDto> GetCategoryByGuid(Guid id);
    Task<string> SafeDeleteCategoryAsync(Guid categoryId);
}
