﻿using Microsoft.Extensions.Hosting;
using ShirtSkirt.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Repositories;
using ShirtSkirt.Services;
using ShirtSkirt;
using Microsoft.Extensions.Logging;
using System;

var hostBuilder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x =>
    {
        x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\db_skirt.mdf;Integrated Security=True;Connect Timeout=30");
        x.LogTo(Console.WriteLine, LogLevel.Warning);
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

    services.AddScoped<UserScreen>();

}).Build();

var secondHostBuilder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<ShirtSkirt.Contexts.AppContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Education\\ShirtSkirt\\ShirtSkirt\\Data\\db_shirt.mdf;Integrated Security=True;Connect Timeout=30"));
}).Build();

var userScreen = hostBuilder.Services.GetRequiredService<UserScreen>();
userScreen.DisplayMenu(userScreen);
