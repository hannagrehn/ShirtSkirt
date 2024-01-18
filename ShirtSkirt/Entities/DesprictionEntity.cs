

using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class DesprictionEntity
{
    [Key]
    public int DescriptionId { get; set; }

    [Required]
    public string Ingress { get; set; } = null!;

    public string? LongDescription { get; set; } 

}
