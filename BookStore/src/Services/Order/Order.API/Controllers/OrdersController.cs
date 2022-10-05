using MassTransit;
using MessagesAndEvents;
using Microsoft.AspNetCore.Mvc;
using Order.API.Commands;
using Order.API.Models;
using Order.API.Queries;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IPublishEndpoint _publishEndpoint;
        private readonly MediatR.IMediator mediator;

        public OrdersController(IPublishEndpoint publishEndpoint, MediatR.IMediator mediator)
        {
            _publishEndpoint = publishEndpoint;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrateOrder(CreateOrderRequest createOrderRequest)
        {
            //db'ye ekler;
            //ve sipariş oluştu eventini fırlatır!
            var order = new Models.Order { CustomerId = createOrderRequest.CustomerID };
            var command = new CreateOrderCommand(order);
            var createdOrder = await mediator.Send(command);

            var orderCreated = new OrderCreatedEvent
            {
                CustomerId = createOrderRequest.CustomerID,
                OrderId = createdOrder.Id,
                OrderItems = createOrderRequest.OrderItems.Select(x => new OrderItemMessage { Price = x.Price, Quantity = x.Quantity, ProductId = x.BookId }).ToList(),
                TotalPrice = createOrderRequest.OrderItems.Sum(x => x.Quantity * x.Price)
            };

            //await _publishEndpoint.Publish<OrderCreatedEvent>(orderCreated);
            return Ok(createdOrder.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {

            var orders = await mediator.Send(new GetOrdersQuery());

            return Ok(orders);
        }
    }
}
