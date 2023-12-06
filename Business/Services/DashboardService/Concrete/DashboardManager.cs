using Business.Services.DashboardService.Abstract;
using DataAccess.UnitOfWorks;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DashboardService.Concrete;
public class DashboardManager:IDashboardService
{
    private readonly IUnitOfWork _unitOfWork;

    public DashboardManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<int>> GetYearlyArticleCounts()
    {
        var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);
        var startDate=DateTime.Now.Date;
        startDate = new DateTime(startDate.Year, 1, 1);

        List<int> datas = new();
        for (int i = 1; i <=12 ; i++)
        {
            var startedDate=new DateTime(startDate.Year, i, 1);
            var endedDate=startedDate.AddMonths(1);
            var data=articles.Where(x=>x.CreatedDate>=startedDate && x.CreatedDate<endedDate).Count();
            datas.Add(data);
        }
        return datas;
    }

    public async Task<int> GetTotalArticleCount()
    {
        var articleCount=await _unitOfWork.GetRepository<Article>().CountAsync();
        return articleCount;
    }

    public async Task<int> GetTotalCategoryCount()
    {
        var categoryCount=await _unitOfWork.GetRepository<Category>().CountAsync();
        return categoryCount;
    }

    public async Task<int> GetTotalUserCount()
    {
        var userCount=await _unitOfWork.GetRepository<AppUser>().CountAsync();
        return userCount;
    }

    public async Task<int> GetTotalDeletedArticleCount()
    {
        var articleCount = await _unitOfWork.GetRepository<Article>().CountAsync(x=>x.IsDeleted);
        return articleCount;
    }
}
