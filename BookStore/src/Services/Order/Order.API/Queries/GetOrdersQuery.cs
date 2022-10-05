using MediatR;

namespace Order.API.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<Models.Order>>
    {
    }
}
