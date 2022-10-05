using MassTransit;
using MessagesAndEvents;

namespace Stock.API.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly IPublishEndpoint _endpoint;

        public OrderCreatedEventConsumer(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            //Eğer stokta varsa StockReserved
            //            yoksa StockNotReserved

            if (checkStock(context.Message.OrderItems))
            {
                await _endpoint.Publish(new StockReservedEvent { CustomerId = context.Message.CustomerId, OrderId = context.Message.OrderId, TotalPrice = context.Message.TotalPrice, OrderItemMessages = context.Message.OrderItems });
            }
            else
            {
                await _endpoint.Publish(new StockNotReserved { CustomerID = context.Message.CustomerId, OrderId = context.Message.OrderId, Message = "Ürün stokları yetersiz" });
            }
        }

        private bool checkStock(List<OrderItemMessage> orderItems)
        {
            return new Random().Next(0, 10) % 2 == 0;
        }
    }
}
