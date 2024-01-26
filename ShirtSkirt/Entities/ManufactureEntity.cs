using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities;

public class ManufactureEntity
{
    [Key]
    public int ManufactureId { get; set; }
    public string ManufactureName { get; set; } = null!;

}
