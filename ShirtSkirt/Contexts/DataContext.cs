using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ManufactureEntity> Manufactures { get; set; }
        public virtual DbSet<DescriptionEntity> Descriptions { get; set; }
        public virtual DbSet<ReviewEntity> Reviews { get; set; }
        public virtual DbSet<PricelistEntity> Prices { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }

    }
}
