using MassTransit;
using MediatR;
using MessagesAndEvents;
using Order.API.Commands;

namespace Order.API.Consumers
{
    public class PaymentFailedConsumer : IConsumer<PaymentFailedEvent>
    {
        private readonly ILogger<PaymentFailedConsumer> _logger;
        private readonly IMediator mediator;

        public PaymentFailedConsumer(ILogger<PaymentFailedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            _logger.LogWarning($"{context.Message.OrderId} siparişi hatalı. Ödeme başarısız");
            mediator.Send(new UpdateOrderStateCommand { OrderId = context.Message.OrderId, State = Models.OrderState.Failed });
            return Task.CompletedTask;
        }
    }
}
