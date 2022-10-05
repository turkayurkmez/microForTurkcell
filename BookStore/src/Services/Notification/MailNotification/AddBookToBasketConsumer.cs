// See https://aka.ms/new-console-template for more information
using MassTransit;
using MessagesAndEvents;

public class AddBookToBasketConsumer : IConsumer<AddBookToBasketRequest>
{
    public Task Consume(ConsumeContext<AddBookToBasketRequest> context)
    {
        Console.WriteLine($"Sepete {context.Message.Name} isimli kitap eklendiğine dair mail gönderildi! ");
        return Task.CompletedTask;
    }
}