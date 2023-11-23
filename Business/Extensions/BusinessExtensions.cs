using Business.Services.ArticleService.Abstract;
using Business.Services.ArticleService.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extensions;
public static class BusinessExtensions
{
    public static IServiceCollection LoadBusinessExtension(this IServiceCollection services)
    {
        var assembly=Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddScoped<IArticleService, ArticleManager>();

        return services;
    }
}
