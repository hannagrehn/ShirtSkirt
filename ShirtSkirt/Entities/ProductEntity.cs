namespace ShirtSkirt.Entities;

public class ProductEntity
{
    public int ArticleNumber { get; set; }

    public string Title { get; set; } = null!;
    public int ManufactureId { get; set; } 
    public int DescriptionId { get; set; }
    public int ReviewId { get; set; }
    public int PriceId { get; set; } 
    public int CategoryId { get; set; }
}
