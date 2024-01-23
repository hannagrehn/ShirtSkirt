using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class CategoryEntity
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = null!;

   
    public virtual ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

    public virtual ProductEntity Product { get; set; } = null!;
}
