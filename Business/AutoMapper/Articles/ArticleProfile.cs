using AutoMapper;
using Entity.DTOs.Articles;
using Entity.Entities;

namespace Business.AutoMapper.Articles;
public class ArticleProfile:Profile
{
    public ArticleProfile()
    {
        CreateMap<ArticleDto,Article>().ReverseMap();
        CreateMap<ArticleAddDto,Article>().ReverseMap();
        CreateMap<ArticleUpdateDto,Article>().ReverseMap();
        CreateMap<ArticleUpdateDto,ArticleDto>().ReverseMap();
    }
}
