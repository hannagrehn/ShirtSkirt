using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Contexts
{
    public class DataContext : DbContext
    {
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
            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.CategoryName)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

                 
        }
    }
}
