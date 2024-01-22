using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ArticleNumber { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ManufactureEntity))]
        public int ManufactureId { get; set; }

        [Required]
        [ForeignKey(nameof(DesprictionEntity))]
        public int DescriptionId { get; set; }

        [Required]
        [ForeignKey(nameof(ReviewEntity))]
        public int ReviewId { get; set; }

        [Required]
        [ForeignKey(nameof(PricelistEntity))]
        public int PriceId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryEntity))]
        public int CategoryId { get; set; }

        public virtual ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

        public virtual ReviewEntity ReviewEntity { get; set; } = null!;
    }
}
