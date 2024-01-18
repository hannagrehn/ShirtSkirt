using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class CategoryEntity
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = null!;

}
