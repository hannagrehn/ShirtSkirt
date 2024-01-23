
using ShirtSkirt.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShirtSkirt.Dtos;

public class CreateProductDto
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public string? ManufactureName { get; set; }

    //public int ManufactureId { get; set; }
    //public int DescriptionId { get; set; }
    //public int ReviewId { get; set; }
    //public int PriceId { get; set; }

    public string CategoryName { get; set; } = null!;
}
