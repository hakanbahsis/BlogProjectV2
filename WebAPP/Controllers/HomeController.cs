using Business.Services.ArticleService.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
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
            var article = await _articleService.GetArticlesWithCategoryNonDeletedAsync(articleId);
            return View(article);
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