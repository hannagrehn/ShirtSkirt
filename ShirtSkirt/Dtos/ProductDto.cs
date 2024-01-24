namespace ShirtSkirt.Dtos;

public class ProductDto
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public int ManufactureId { get; set; }
    public string ManufactureName { get; set; } = null!;

    public int DescriptionId { get; set; }
    public string Ingress { get; set; } = null!;
    public string LongDescription { get; set; } = null!;

    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; } = null!;
    public string ReviewerName { get; set; } = null!;
    public DateTime ReviewDate { get; set; }

    public int PriceId { get; set; }
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
}
