namespace ShirtSkirt.Dtos;

public class CreateProductDto
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string ManufactureName { get; set; } = null!;
    public string Ingress { get; set; } = null!;
    public string LongDescription { get; set; } = null!;
    public string ReviewerName { get; set; } = null!;
    public int Rating { get; set; }
    public string ReviewText { get; set; } = null!;
    public DateTime ReviewDate { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = null!;
}
