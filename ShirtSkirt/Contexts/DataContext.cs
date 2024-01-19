using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ManufactureEntity> Manufactures { get; set; }
        public virtual DbSet<DesprictionEntity> Descriptions { get; set; }
        public virtual DbSet<ReviewEntity> Reviews { get; set; }
        public virtual DbSet<PricelistEntity> Prices { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesprictionEntity>()
                .HasIndex(x => x.DescriptionId)
                .IsUnique();

            modelBuilder.Entity<ReviewEntity>()
                .HasIndex(x => x.ReviewId)
                .IsUnique();

            modelBuilder.Entity<PricelistEntity>()
                .HasIndex(x => x.PriceId)
                .IsUnique();
        }
    }
}
