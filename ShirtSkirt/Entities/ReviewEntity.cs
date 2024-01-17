
using System.ComponentModel.DataAnnotations;


namespace ShirtSkirt.Entities;

public class ReviewEntity
{

    [Key]
    public int RewievId { get; set; }

    public string RewieverName { get; set; } = null!;
    public int Rating { get; set; }
    public string RewievText { get; set; } = null!;
    public string ReviewDate { get; set; } = null!;
}
