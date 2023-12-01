using AutoMapper;
using Entity.DTOs.Categories;
using Entity.Entities;

namespace Business.AutoMapper.Categories;
public class CategoryProfile:Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CategoryAddDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
    }
}
