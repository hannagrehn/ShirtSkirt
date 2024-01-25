using Microsoft.Extensions.Hosting;
using ShirtSkirt.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Repositories;
using ShirtSkirt.Services;
using ShirtSkirt.Dtos;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\skirt_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    services.AddScoped<ProductRepo>();
    services.AddScoped<ProductService>();
    services.AddScoped<CategoryRepo>();
    services.AddScoped<DescriptionRepo>();
    services.AddScoped<ManufactureRepo>();
    services.AddScoped<PriceRepo>();
    services.AddScoped<ReviewRepo>();

}).Build();


builder.Start();

var productService = builder.Services.GetRequiredService<ProductService>();
var result = productService.CreateProduct(new CreateProductDto
{
    ArticleNumber = "A1",
    Title = "NiceShooe",
    ManufactureName = "Gucci",
    Ingress = "Highheel",
    LongDescription = "Very good shoe",
    ReviewerName = "John Doe",
    Rating = 5,
    ReviewText = "Excellent product",
    ReviewDate = DateTime.Now,
    Price = 2000,
    CategoryName = "Shoes"
});

if (result)
    Console.WriteLine("YES");
else
    Console.WriteLine("Error");
Console.ReadKey();
