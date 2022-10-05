using MassTransit;
using MessagesAndEvents;

namespace Order.API.Consumers
{
    public class PaymentCompletedConsumer : IConsumer<PaymentCompletedEvent>
    {
        private readonly ILogger<PaymentCompletedConsumer> _logger;

        public PaymentCompletedConsumer(ILogger<PaymentCompletedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            _logger.LogInformation($"{context.Message.OrderId} başarılı bir şekilde tamamlandı");
            return Task.CompletedTask;
        }
    }
}
