using Basket.API.Services;
using MassTransit;
using MessagesAndEvents;

namespace Basket.API.Consumers
{
    public class AddBookToBasketRequestConsumer : IConsumer<AddBookToBasketRequest>
    {
        private readonly ILogger<AddBookToBasketRequestConsumer> _logger;
        private readonly IBasketService _basketService;
        public AddBookToBasketRequestConsumer(ILogger<AddBookToBasketRequestConsumer> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;

        }
        public Task Consume(ConsumeContext<AddBookToBasketRequest> context)
        {

            _logger.LogInformation($"{context.Message.UserId} nolu kullanıcı; {context.Message.Name} isimli kitabı sepete ekledi");
            //Burada; değişim db'ye veya noSql kaynağına MongoDb) ya da reDis üzerine kaydedilebilir.
            _basketService.AddToBasket(new Book { Description = context.Message.Description, Id = context.Message.BookId, Name = context.Message.Name, Price = context.Message.Price, Quantity = context.Message.Quantity });
            return Task.CompletedTask;
        }
    }
}
