using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ProductEntity
{
    [Key]
    public int ArticleNumber { get; set; }

    [Required]
    public string Title { get; set; } = null!;


    [Required]
    [ForeignKey(nameof(ManufactureEntity))]
    public int ManufactureId { get; set; }

    [Required]
    [ForeignKey(nameof(DesprictionEntity))]
    public int DescriptionId { get; set; }

    [Required]
    [ForeignKey (nameof(ReviewEntity ))]
    public int ReviewId { get; set; }


    [Required]
    [ForeignKey(nameof(PricelistEntity))]
    public int PriceId { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryEntity))]
    public int CategoryId { get; set; }
}

