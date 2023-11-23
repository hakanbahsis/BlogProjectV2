namespace Business.Services.ArticleService.Abstract;

using Entity.DTOs.Articles;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticlesAsync();
}

