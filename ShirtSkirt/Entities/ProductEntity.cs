﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities
{
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

        [Required]
        [ForeignKey(nameof(CategoryEntity))]
        public int CategoryId { get; set; }



        public virtual ICollection<ReviewEntity> Reviews { get; set; } = new HashSet<ReviewEntity>();

        public virtual ReviewEntity ReviewEntity { get; set; } = null!;



        public virtual ICollection<CategoryEntity> Categories { get; set; } = new HashSet<CategoryEntity>();

        public virtual CategoryEntity CategoryEntity { get; set; } = null!;


    }
}
