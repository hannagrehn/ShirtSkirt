namespace ShirtSkirt.Dtos;

public class ProductDto
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public int ManufactureId { get; set; }
    public int DescriptionId { get; set; }
    public int ReviewId { get; set; }
    public int PriceId { get; set; }
    public int CategoryId { get; set; }


    public string CategoryName { get; set; } = null!;
}
