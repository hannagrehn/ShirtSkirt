using Microsoft.Extensions.Hosting;
using ShirtSkirt.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Repositories;
using ShirtSkirt.Services;
using System;
using ShirtSkirt;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\db_skirt.mdf;Integrated Security=True;Connect Timeout=30");
            options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Warning);
        });

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

        services.AddDbContext<ShirtSkirt.Contexts.AppContext>(options =>
        {
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\db_shirt.mdf;Integrated Security=True;Connect Timeout=30");
        });

        services.AddScoped<AllianceRepo>();
        services.AddScoped<LanguageRepo>();
        services.AddScoped<RoleRepo>();
        services.AddScoped<ProfileRepo>();
        services.AddScoped<AllianceService>();
        services.AddScoped<LanguageService>();
        services.AddScoped<RoleService>();
        services.AddScoped<ProfileService>();

        services.AddScoped<UserScreen>();
    })
    .Build();

var userScreen = host.Services.GetRequiredService<UserScreen>();
userScreen.DisplayMenu(userScreen);

//yes that will work