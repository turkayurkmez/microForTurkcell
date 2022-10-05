using MassTransit;
using MessagesAndEvents;

namespace Payment.API.Consumer
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        private readonly IPublishEndpoint _publish;

        public StockReservedEventConsumer(IPublishEndpoint publish)
        {
            _publish = publish;
        }

        public async Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            //ödeme al:
            //başarılı -> PaymentCompleted
            //başarısız -> PaymentFailed
            if (paymentSuccess())
            {
                await _publish.Publish(new PaymentCompletedEvent { OrderId = context.Message.OrderId });
            }
            else
            {
                await _publish.Publish(new PaymentFailedEvent { OrderId = context.Message.OrderId, Message = "Banka hata döndürdü" });
            }
        }

        private bool paymentSuccess()
        {
            return new Random().Next(0, 10) % 2 == 0;
        }
    }
}
