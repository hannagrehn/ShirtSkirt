using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class ManufactureEntity
{
    [Key]
    public int ManufactureId { get; set; }

    [Required]
    public string ManufactureName { get; set; } = null!;

}
