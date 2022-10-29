using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RS.Application.Product;
using RS.Application.ProductCategory;
using RS.Application.ProductPicture;
using RS.Application.Slide;
using RS.Domain.Entities.ProductAgg;
using RS.Domain.Entities.ProductCategoryAgg;
using RS.Domain.Entities.ProductPictureAgg;
using RS.Domain.Entities.SlideAgg;
using RS.Infrastructure.Repositories;

namespace RS.Infrastructure
{
    public class ConfigureServices
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

            //services.AddTransient<ISideQuery, SlideQuery>();
            //services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            //services.AddTransient<IProductQuery, ProductQuery>();

            //services.AddTransient<IPermissionExposer, RealStatePermissionExposer>();

            services.AddDbContext<RealStateContext>(x => x.UseSqlServer(connectionString));
        }
    }
}