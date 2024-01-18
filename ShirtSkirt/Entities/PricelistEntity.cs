
using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Entities;

public class PricelistEntity
{
    [Key]
    public int PriceId { get; set; }

    [Required]
    public int Price {  get; set; }
   
    public int DiscountedPrice { get; set; }

}
