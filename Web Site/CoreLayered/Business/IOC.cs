using Business.Services;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.MapProfiles;
using Data;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    //Inversions/Injections of Control : UI katmanında olması gereken fakat güvenlkik ve performans nedeniyle bağlanmayan tüm ayarlar buradan aktarılır.
    public static class IOC
    {
        public static IServiceCollection AddDataTransactions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ArticleProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<TagProfile>();
            });

            services.AddDbContext<MagazineContext>(opt => opt.UseSqlite(configuration.GetConnectionString("news")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INewsService, NewsService>();

            return services;
        }
    }
}
