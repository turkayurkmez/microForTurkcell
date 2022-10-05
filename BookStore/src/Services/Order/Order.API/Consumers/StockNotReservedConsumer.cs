using MassTransit;
using MessagesAndEvents;

namespace Order.API.Consumers
{
    public class StockNotReservedConsumer : IConsumer<StockNotReserved>
    {
        private readonly ILogger<StockNotReserved> _logger;

        public StockNotReservedConsumer(ILogger<StockNotReserved> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StockNotReserved> context)
        {
            _logger.LogWarning($"{context.Message.OrderId} başarısız oldu. Stokta yok");
            return Task.CompletedTask;
        }
    }
}
