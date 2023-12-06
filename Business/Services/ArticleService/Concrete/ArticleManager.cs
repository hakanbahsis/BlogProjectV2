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

    public async Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
    {
        pageSize = pageSize > 20 ? 20 : pageSize;

        var articles = categoryId == null
            ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
            : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted, x => x.Category, i => i.Image, u => u.User);

        var sortedArticles = isAscending
            ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
            : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        return new ArticleListDto
        {
            Articles = sortedArticles,
            CategoryId = categoryId == null ? null : categoryId.Value,
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalCount = articles.Count,
            IsAscending = isAscending
        };
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

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
        var map = _mapper.Map<List<ArticleDto>>(articles);
        return map;
    }

    public async Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image,u=>u.User);
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

    public async Task<string> UndoDeleteArticleAsync(Guid articleId)
    {
        var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

        article.IsDeleted = false;
        article.DeletedDate = null;
        article.DeletedBy = null;
        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();
        return article.Title;
    }

    public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var userEmail = _user.GetLoggedInEmail();
        var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);
        if (articleUpdateDto.Photo != null)
        {
            _imageHelper.DeleteImage(article.Image.FileName);

            var imageUpload = await _imageHelper.UploadImageAsync(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
            Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            article.ImageId = image.Id;
        }
        //_mapper.Map(articleUpdateDto, article);
        article.Title = articleUpdateDto.Title;
        article.Content = articleUpdateDto.Content;
        article.CategoryId = articleUpdateDto.CategoryId;
        article.ModifiedDate = DateTime.Now;
        article.ModifiedBy = userEmail;
        await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
        await _unitOfWork.SaveAsync();

        return article.Title;
    }

    public async Task<ArticleListDto> SourceAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
    {
        pageSize = pageSize > 20 ? 20 : pageSize;

        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted
        && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword))
        , a => a.Category, i => i.Image, u => u.User);

        var sortedArticles = isAscending
            ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
            : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        return new ArticleListDto
        {
            Articles = sortedArticles,
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalCount = articles.Count,
            IsAscending = isAscending
        };
    }
}
