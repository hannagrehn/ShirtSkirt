using Microsoft.Extensions.Hosting;
using ShirtSkirt.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\ShirtSkirt\ShirtSkirt\Data\skirt_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

});

builder.Build();