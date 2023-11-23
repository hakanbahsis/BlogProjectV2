using AutoMapper;
using Business.Services.ArticleService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.DTOs.Articles;
using Entity.Entities;

namespace Business.Services.ArticleService.Concrete;
public class ArticleManager : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ArticleDto>> GetAllArticlesAsync()
    {
        var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync();
        var map=_mapper.Map<List<ArticleDto>>(articles);
        return map;
    }
}
