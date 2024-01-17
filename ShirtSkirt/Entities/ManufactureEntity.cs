using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class ManufactureEntity
{
    [Key]
    public int ArticleNumber { get; set; }

    [Required]
    public string ManufactureName { get; set; } = null!;

}
