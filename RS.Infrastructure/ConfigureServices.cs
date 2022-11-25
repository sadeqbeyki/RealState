using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RS.Application;
using RS.Contracts.ProductPictures;
using RS.Contracts.Products;
using RS.Contracts.ProductCategories;
using RS.Contracts.Slides;
using RS.Domain.Entities.ProductAgg;
using RS.Domain.Entities.ProductCategoryAgg;
using RS.Domain.Entities.ProductPictureAgg;
using RS.Domain.Entities.SlideAgg;
using RS.Infrastructure.Repositories;

namespace RS.Infrastructure
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddDbContext<RealStateContext>(x => x.UseSqlServer(connectionString));
        }
    }
}