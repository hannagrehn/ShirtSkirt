using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ManufactureEntity
{
    [Key]
    public int ManufactureId { get; set; }

    [Required]
    public string ManufactureName { get; set; } = null!;

    [NotMapped]
    public virtual ICollection<ProductEntity> Products { get; set; } 

    public virtual ProductEntity Product { get; set; } = null!;
}
