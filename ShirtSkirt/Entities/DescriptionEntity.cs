
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class DescriptionEntity
{
    [Key]
    public int DescriptionId { get; set; }
    public string Ingress { get; set; } = null!;
    public string? LongDescription { get; set; } 

}


