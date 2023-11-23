using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;
public static class DataAccessExtensions
{
    public static IServiceCollection LoadDataAccessExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepository<>));
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        services.AddDbContext<AppDbContext>(
                    opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
