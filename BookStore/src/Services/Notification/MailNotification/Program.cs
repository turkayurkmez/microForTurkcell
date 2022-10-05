// See https://aka.ms/new-console-template for more information
using MassTransit;



var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("localhost", "/", host =>
    {
        host.Username("guest");
        host.Password("guest");
    });

    cfg.ReceiveEndpoint("AddBookToBasketRequest", e =>
    {
        e.Consumer<AddBookToBasketConsumer>();
    });
});

busControl.Start();
Console.ReadLine();