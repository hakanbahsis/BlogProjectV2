using Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CategoryService.Abstract;
public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
}
