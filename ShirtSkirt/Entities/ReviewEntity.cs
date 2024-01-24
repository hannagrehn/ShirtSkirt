using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ReviewEntity
{
    [Key]
    public int ReviewId { get; set; }

    [Required]
    public string ReviewerName { get; set; } = null!;

    [Required]
    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime ReviewDate { get; set; }

    [Required]
    public int ProductId { get; set; }

    public virtual ProductEntity Product { get; set; } = null!;
    public virtual ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
