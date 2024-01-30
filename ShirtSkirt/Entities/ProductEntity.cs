
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;


    [ForeignKey("ManufactureId")]
    public int ManufactureId { get; set; }
    public ManufactureEntity ManufactureName { get; set; } = null!;


    [ForeignKey("DescriptionId")]
    public int DescriptionId { get; set; }
    public DescriptionEntity Ingress { get; set; } = null!;


    [ForeignKey("ReviewId")]
    public int ReviewId { get; set; }
    public ReviewEntity ReviewText { get; set; } = null!;


    [ForeignKey("PriceId")]
    public int PriceId { get; set; }
    public PricelistEntity Price { get; set; } = null!;


    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public CategoryEntity CategoryName { get; set; } = null!;

}
