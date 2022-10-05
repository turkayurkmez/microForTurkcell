using Basket.API.Consumers;
using Basket.API.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBasketService, BookService>();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<AddBookToBasketRequestConsumer>();
    configurator.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        config.ConfigureEndpoints(context);
    });


});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
