
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
    public ManufactureEntity Manufacture { get; set; } = null!;


    [ForeignKey("DescriptionId")]
    public int DescriptionId { get; set; }
    public DescriptionEntity Description { get; set; } = null!;


    [ForeignKey("ReviewId")]
    public int ReviewId { get; set; }
    public ReviewEntity Review { get; set; } = null!;


    [ForeignKey("PriceListId")]
    public int PriceListId { get; set; }
    public PricelistEntity PriceList { get; set; } = null!;


    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

}
