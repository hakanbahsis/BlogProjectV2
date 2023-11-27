using AutoMapper;
using Business.Extensions;
using Business.Services.ArticleService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.DTOs.Articles;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Services.ArticleService.Concrete;
public class ArticleManager : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ClaimsPrincipal _user;

    public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _user = _contextAccessor.HttpContext.User;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        //var userId = Guid.Parse("4505611C-4DDD-46DA-9FB8-32D402ECA8D3");
       // var userId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
       var userId=_user.GetLoggedInUserId();
        var userEmail=_user.GetLoggedInEmail();
        var imageId = Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23");
        var article = new Article
        (
            articleAddDto.Title,
            articleAddDto.Content,
            userId,
            userEmail,
            articleAddDto.CategoryId,
            imageId
       );

        await _unitOfWork.GetRepository<Article>().AddAsync(article);
        await _unitOfWork.SaveAsync();

    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {
        var articles= await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted,x=>x.Category);
        var map=_mapper.Map<List<ArticleDto>>(articles);
        return map;
    }

    public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id==articleId, x => x.Category);
        var map = _mapper.Map<ArticleDto>(article);
        return map;
    }

    public async Task<string> SafeDeleteArticleAsync(Guid articleId)
    {
        var userEmail = _user.GetLoggedInEmail();
        var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
        article.IsDeleted = true;
        article.DeletedDate=DateTime.Now;
        article.DeletedBy = userEmail;
        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();
        return article.Title;
    }

    public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var userEmail = _user.GetLoggedInEmail();
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
        article.ModifiedDate = DateTime.Now;
        article.ModifiedBy = userEmail;
        _mapper.Map<ArticleUpdateDto,Article>(articleUpdateDto,article);
        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();

        return article.Title;
    }
}
