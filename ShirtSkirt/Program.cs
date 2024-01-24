using Microsoft.Extensions.Hosting;
using ShirtSkirt.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Repositories;
using ShirtSkirt.Services;
using ShirtSkirt.Dtos;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\skirt_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    services.AddSingleton<CategoryRepo>();
    services.AddSingleton<ProductRepo>();
    services.AddSingleton<ProductService>();

}).Build();

builder.Start();


var productService = builder.Services.GetRequiredService<ProductService>();
var result = productService.CreateProduct(new CreateProductDto
{
    ArticleNumber = "A1",
    Title = "A1 title",
    CategoryName = "Test",
    //ManufactureId = 1,
    //DescriptionId = 2,
    //ReviewId = 3,
    //PriceId = 4,
    //CategoryId = 1

});

if (result)
    Console.WriteLine("YES");
else 
    Console.WriteLine("Helvete");
Console.ReadKey();