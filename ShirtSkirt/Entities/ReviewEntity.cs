
using System.ComponentModel.DataAnnotations;


namespace ShirtSkirt.Entities;

public class ReviewEntity
{

    [Key]
    public int RewievId { get; set; }

    [Required]
    public string RewieverName { get; set; } = null!;

    [Required]
    public int Rating { get; set; }

    public string? RewievText { get; set; } 

    [Required]
    public string ReviewDate { get; set; } = null!;

}
