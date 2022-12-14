using MassTransit;
using MediatR;
using Order.API.Consumers;
using Order.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddSingleton<FakeDataSource>();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<PaymentCompletedConsumer>();
    configurator.AddConsumer<PaymentFailedConsumer>();
    configurator.AddConsumer<StockNotReservedConsumer>();


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
