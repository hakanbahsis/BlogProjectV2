using Business.Helpers.Images;
using Business.Services.ArticleService.Abstract;
using Business.Services.ArticleService.Concrete;
using Business.Services.ArticleService.Validation;
using Business.Services.CategoryService.Abstract;
using Business.Services.CategoryService.Concrete;
using Business.Services.DashboardService.Abstract;
using Business.Services.DashboardService.Concrete;
using Business.Services.UserService.Abstract;
using Business.Services.UserService.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace Business.Extensions;
public static class BusinessExtensions
{
    public static IServiceCollection LoadBusinessExtension(this IServiceCollection services)
    {
        var assembly=Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddControllersWithViews().AddFluentValidation(opt =>
        {
            opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
            opt.DisableDataAnnotationsValidation=true;
            opt.ValidatorOptions.LanguageManager.Culture=new CultureInfo("tr-tr");
        });

        services.AddScoped<IArticleService, ArticleManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IDashboardService, DashboardManager>();
        services.AddScoped<IImageHelper, ImageHelper>();

        return services;
    }
}
