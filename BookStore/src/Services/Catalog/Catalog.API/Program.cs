using Catalog.Application;
using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookRepository, EFBookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
var defaultHost = builder.Configuration.GetValue<string>("DefaultHost");
var connectionString = builder.Configuration.GetConnectionString("db");
connectionString = connectionString.Replace("[HOST]", defaultHost);
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("Catalog.DataAccess")));

Console.WriteLine($"Dikkat: Bağlantı {connectionString}");


var app = builder.Build();

var dbInstance = app.Services.CreateScope().ServiceProvider.GetRequiredService<CatalogDbContext>();
PrepareDb.Initialize(dbInstance);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
