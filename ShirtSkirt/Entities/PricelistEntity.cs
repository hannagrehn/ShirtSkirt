using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShirtSkirt.Entities
{
    public class PricelistEntity
    {
        [Key]
        public int PriceId { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(10,2)]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        [Precision(10, 2)]
        public decimal? DiscountedPrice { get; set; }
    }
}
