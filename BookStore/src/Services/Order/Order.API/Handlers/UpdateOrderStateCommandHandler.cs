using MediatR;
using Order.API.Commands;
using Order.API.Services;

namespace Order.API.Handlers
{
    public class UpdateOrderStateCommandHandler : IRequestHandler<UpdateOrderStateCommand, Models.Order>
    {
        private readonly FakeDataSource fakeDataSource;

        public UpdateOrderStateCommandHandler(FakeDataSource fakeDataSource)
        {
            this.fakeDataSource = fakeDataSource;
        }

        public async Task<Models.Order> Handle(UpdateOrderStateCommand request, CancellationToken cancellationToken)
        {
            await fakeDataSource.UpdateOrderState(request.OrderId, request.State);
            var orders = await fakeDataSource.GetOrdersAsync();
            var updatedOrder = orders.FirstOrDefault(x => x.Id == request.OrderId);
            return updatedOrder;
        }
    }
}
