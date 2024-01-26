
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;


    public int ManufactureId { get; set; }
    public ManufactureEntity ManufactureName { get; set; } = null!;

    public int DescriptionId { get; set; }
    public DescriptionEntity Ingress { get; set; } = null!;

    public int ReviewId { get; set; }
    public ReviewEntity ReviewText { get; set; } = null!;

    public int PriceId { get; set; }
    public PricelistEntity Price { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity CategoryName { get; set; } = null!;

}
