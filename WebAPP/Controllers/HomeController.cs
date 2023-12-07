using Business.Services.ArticleService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System.Diagnostics;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _articleService = articleService;
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId,int currentPage=1,int pageSize=3,bool isAscending=false)
        {
            var articles=await _articleService.GetAllByPagingAsync(categoryId,currentPage,pageSize,isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword,int currentPage=1,int pageSize=3,bool isAscending=false)
        {
            var articles=await _articleService.SourceAsync(keyword,currentPage,pageSize,isAscending);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid articleId)
        {
            var ipAddress = _contextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articleVisitors = await _unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == articleId);

            var result = await _articleService.GetArticlesWithCategoryNonDeletedAsync(articleId);

            var visitor=await _unitOfWork.GetRepository<Visitor>().GetAsync(x=>x.IpAddress == ipAddress);
            var addArticleVisitors = new ArticleVisitor(article.Id, visitor.Id);
            if (articleVisitors.Any(x => x.VisitorId == addArticleVisitors.VisitorId && x.ArticleId == addArticleVisitors.ArticleId)) 
            {
                return View(result);
            }

            else
            {
                await _unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors);
                article.ViewCount += 1;
                await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await _unitOfWork.SaveAsync();
            }

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}