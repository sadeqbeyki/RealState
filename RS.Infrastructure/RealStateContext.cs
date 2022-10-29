using Microsoft.EntityFrameworkCore;
using RS.Domain.Entities.ProductAgg;
using RS.Domain.Entities.ProductCategoryAgg;
using RS.Domain.Entities.ProductPictureAgg;
using RS.Domain.Entities.SlideAgg;
using RS.Infrastructure.Configurations;

namespace RS.Infrastructure
{
    public class RealStateContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public RealStateContext(DbContextOptions<RealStateContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
