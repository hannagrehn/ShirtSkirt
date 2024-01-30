using Microsoft.Extensions.Hosting;
using ShirtSkirt.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Repositories;
using ShirtSkirt.Services;
using ShirtSkirt.Dtos;
using ShirtSkirt;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x =>
        x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\shirt_db.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<CategoryRepo>(); 
    services.AddScoped<DescriptionRepo>();
    services.AddScoped<ManufactureRepo>();
    services.AddScoped<PriceRepo>();
    services.AddScoped<ReviewRepo>();
    services.AddScoped<ProductRepo>();

    services.AddScoped<CategoryService>();
    services.AddScoped<DescriptionService>();
    services.AddScoped<ManufactureService>();
    services.AddScoped<PriceService>();
    services.AddScoped<ReviewService>();
    services.AddScoped<ProductService>();
  
    services.AddScoped<UserScreen>();

}).Build();


var userScreen = builder.Services.GetRequiredService<UserScreen>();
userScreen.CreateProduct_UI();