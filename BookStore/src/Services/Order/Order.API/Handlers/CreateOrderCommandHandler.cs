using MediatR;
using Order.API.Commands;
using Order.API.Services;

namespace Order.API.Handlers
{

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Models.Order>
    {
        //public void Handle(CreateOrderCommand command)
        //{
        //    //burada db'ye repository veya unit of work veya dbContext aracılığıyla kaydedilecek.

        //}
        private readonly FakeDataSource fakeDataSource;

        public CreateOrderCommandHandler(FakeDataSource fakeDataSource)
        {
            this.fakeDataSource = fakeDataSource;
        }

        public async Task<Models.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await fakeDataSource.AddOrder(request.Order);
            return request.Order;
        }
    }
}
