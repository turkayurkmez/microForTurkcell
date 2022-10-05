using MassTransit;
using MessagesAndEvents;

namespace Shipment.API.Consumers
{
    public class PaymentCompleteEventConsumer : IConsumer<PaymentCompletedEvent>
    {
        private readonly ILogger<PaymentCompleteEventConsumer> _logger;

        public PaymentCompleteEventConsumer(ILogger<PaymentCompleteEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            _logger.LogInformation("Ödeme başarılı...");
            return Task.CompletedTask;
        }
    }
}
