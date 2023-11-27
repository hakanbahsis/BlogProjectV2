namespace Business.Services.ArticleService.Abstract;

using Entity.DTOs.Articles;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
    Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId);
    Task CreateArticleAsync(ArticleAddDto articleAddDto);
    Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
    Task<string> SafeDeleteArticleAsync(Guid articleId);
}

