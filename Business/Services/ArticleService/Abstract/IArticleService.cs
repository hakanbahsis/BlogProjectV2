namespace Business.Services.ArticleService.Abstract;

using Entity.DTOs.Articles;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
    Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();
    Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId);
    Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
    Task<ArticleListDto> SourceAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
    Task CreateArticleAsync(ArticleAddDto articleAddDto);
    Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
    Task<string> SafeDeleteArticleAsync(Guid articleId);
    Task<string> UndoDeleteArticleAsync(Guid articleId);
}

