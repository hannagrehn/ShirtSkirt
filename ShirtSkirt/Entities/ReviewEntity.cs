using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ReviewEntity
{
    [Key]
    public int ReviewId { get; set; }

    public string ReviewerName { get; set; } = null!;

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime ReviewDate { get; set; }
   
}
