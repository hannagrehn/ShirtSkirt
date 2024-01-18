
using System.ComponentModel.DataAnnotations;


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

    [Required]
    public string ReviewDate { get; set; } = null!;

}
