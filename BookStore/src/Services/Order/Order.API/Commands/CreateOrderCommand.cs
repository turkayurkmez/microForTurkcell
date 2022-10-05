using MediatR;

namespace Order.API.Commands
{
    public class CreateOrderCommand : IRequest<Models.Order>
    {
        public Models.Order Order { get; set; }

        public CreateOrderCommand(Models.Order order)
        {
            Order = order;
        }
    }
}
