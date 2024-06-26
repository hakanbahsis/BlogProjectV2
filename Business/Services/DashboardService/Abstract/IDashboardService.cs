﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.DashboardService.Abstract;
public interface IDashboardService
{
    Task<List<int>> GetYearlyArticleCounts();
    Task<int> GetTotalArticleCount();
    Task<int> GetTotalDeletedArticleCount();
    Task<int> GetTotalCategoryCount();
    Task<int> GetTotalUserCount();
}
