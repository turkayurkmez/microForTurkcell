using MediatR;
using Order.API.Queries;
using Order.API.Services;

namespace Order.API.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Models.Order>>
    {
        private readonly FakeDataSource fakeDataSource;

        public GetOrdersHandler(FakeDataSource fakeDataSource)
        {
            this.fakeDataSource = fakeDataSource;
        }

        public async Task<IEnumerable<Models.Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await fakeDataSource.GetOrdersAsync();
        }
    }
}
