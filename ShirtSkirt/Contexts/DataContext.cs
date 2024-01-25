using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() 
        { 
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ManufactureEntity> Manufactures { get; set; }
        public virtual DbSet<DescriptionEntity> Descriptions { get; set; }
        public virtual DbSet<ReviewEntity> Reviews { get; set; }
        public virtual DbSet<PricelistEntity> Prices { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ManufactureEntity>()
                .HasIndex(x => x.ManufactureId);

            modelBuilder.Entity<DescriptionEntity>()
                .HasIndex(x => x.DescriptionId)
                .IsUnique();

            modelBuilder.Entity<ReviewEntity>()
                .HasIndex(x => x.ReviewId)
                .IsUnique();

            modelBuilder.Entity<ReviewEntity>()
                .HasOne(review => review.Product)
                .WithMany(product => product.Reviews)
                .HasForeignKey(review => review.ProductId);


            modelBuilder.Entity<PricelistEntity>()
                .HasIndex(x => x.PriceId)
                .IsUnique();

        
            modelBuilder.Entity<CategoryEntity>()
                .HasMany(category => category.Products)
                .WithOne(product => product.CategoryEntity)
                .HasForeignKey(product => product.CategoryId);


            modelBuilder.Entity<ProductEntity>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);

        }
    }
}
