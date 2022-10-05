using MediatR;
using Order.API.Models;

namespace Order.API.Commands
{
    public class UpdateOrderStateCommand : IRequest<Models.Order>
    {
        public int OrderId { get; set; }
        public OrderState State { get; set; }


    }
}
