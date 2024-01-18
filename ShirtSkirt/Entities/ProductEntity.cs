using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class ProductEntity
{
    [Key]
    public int ArticleNumber { get; set; }

    [Required]
    public string Title { get; set; } = null!;


    [Required]
    public int ManufactureId { get; set; }

    [Required]
    public int DescriptionId { get; set; }

    [Required]
    public int ReviewId { get; set; }

    [Required]
    public int PriceId { get; set; }

    [Required]
    public int CategoryId { get; set; }
}
