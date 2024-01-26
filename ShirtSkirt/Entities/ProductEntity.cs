
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ManufactureEntity))]
    public int ManufactureId { get; set; }

    [Required]
    [ForeignKey(nameof(DescriptionEntity))]
    public int DescriptionId { get; set; }

    [Required]
    [ForeignKey(nameof(ReviewEntity))]
    public int ReviewId { get; set; }

    [Required]
    [ForeignKey(nameof(PricelistEntity))]
    public int PriceId { get; set; }

    [ForeignKey(nameof(CategoryEntity))]
    [Required]
    public int CategoryId { get; set; }



    public virtual ICollection<ReviewEntity> Reviews { get; set; } 
    public virtual ReviewEntity ReviewEntity { get; set; } = null!;

    public virtual ICollection<CategoryEntity> Categories { get; set; } 
    public virtual CategoryEntity CategoryEntity { get; set; } = null!;

    public virtual ManufactureEntity ManufactureEntity { get; set; } = null!;
    public virtual DescriptionEntity DescriptionEntity { get; set; } = null!;
    public virtual PricelistEntity PricelistEntity { get; set; } = null!;


}
