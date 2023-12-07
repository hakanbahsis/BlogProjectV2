using Entity.DTOs.Categories;

namespace Business.Services.CategoryService.Abstract;
public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
    Task<List<CategoryDto>> GetAllCategoriesDeleted();
    Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();
    Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
    Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryAddDto);
    Task<CategoryUpdateDto> GetCategoryByGuid(Guid id);
    Task<string> SafeDeleteCategoryAsync(Guid categoryId);
    Task<string> UndoDeletedCategoryAsync(Guid categoryId);
}
