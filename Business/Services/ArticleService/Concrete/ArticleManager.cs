using AutoMapper;
using Business.Extensions;
using Business.Helpers.Images;
using Business.Services.ArticleService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.DTOs.Articles;
using Entity.Entities;
using Entity.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Services.ArticleService.Concrete;
public class ArticleManager : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ClaimsPrincipal _user;
    private readonly IImageHelper _imageHelper;

    public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor, IImageHelper imageHelper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _user = _contextAccessor.HttpContext.User;
        _imageHelper = imageHelper;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        //var userId = Guid.Parse("4505611C-4DDD-46DA-9FB8-32D402ECA8D3");
        // var userId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
        var userId = _user.GetLoggedInUserId();
        var userEmail = _user.GetLoggedInEmail();
        //var imageId = Guid.Parse("C0F62248-8220-49ED-8354-1A5ED2A5FF23");
        var imageUpload = await _imageHelper.UploadImageAsync(articleAddDto.Title, articleAddDto.Photo, ImageType.Post);
        Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
        await _unitOfWork.GetRepository<Image>().AddAsync(image);
        var article = new Article
        (
            articleAddDto.Title,
            articleAddDto.Content,
            userId,
            userEmail,
            articleAddDto.CategoryId,
            image.Id
       );

        await _unitOfWork.GetRepository<Article>().AddAsync(article);
        await _unitOfWork.SaveAsync();

    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = _mapper.Map<List<ArticleDto>>(articles);
        return map;
    }

    public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category,i=>i.Image);
        var map = _mapper.Map<ArticleDto>(article);
        return map;
    }

    public async Task<string> SafeDeleteArticleAsync(Guid articleId)
    {
        var userEmail = _user.GetLoggedInEmail();
        var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
        article.IsDeleted = true;
        article.DeletedDate = DateTime.Now;
        article.DeletedBy = userEmail;
        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();
        return article.Title;
    }

    public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var userEmail = _user.GetLoggedInEmail();
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category,i=>i.Image);
        if (articleUpdateDto.Photo !=null)
        {
            _imageHelper.DeleteImage(article.Image.FileName);

            var imageUpload = await _imageHelper.UploadImageAsync(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            article.ImageId = image.Id;
        }
       // _mapper.Map(articleUpdateDto, article);
       article.Title = articleUpdateDto.Title;
        article.Content= articleUpdateDto.Content;
        article.CategoryId = articleUpdateDto.CategoryId;
        article.ModifiedDate = DateTime.Now;
        article.ModifiedBy = userEmail;
        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();

        return article.Title;
    }
}
