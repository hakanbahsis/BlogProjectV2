using AutoMapper;
using Entity.DTOs.Articles;
using Entity.Entities;

namespace Business.AutoMapper.Articles;
public class ArticleProfile:Profile
{
    public ArticleProfile()
    {
        CreateMap<ArticleDto,Article>().ReverseMap();
    }
}
