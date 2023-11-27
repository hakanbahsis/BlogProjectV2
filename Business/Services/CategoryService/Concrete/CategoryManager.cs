using AutoMapper;
using Business.Services.CategoryService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.DTOs.Categories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.CategoryService.Concrete;
public class CategoryManager : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
    {
        var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
        var map=_mapper.Map<List<CategoryDto>>(categories);
        return map;
    }
}
