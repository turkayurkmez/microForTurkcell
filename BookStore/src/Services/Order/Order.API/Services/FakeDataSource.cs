using Order.API.Models;

namespace Order.API.Services
{
    public class FakeDataSource
    {
        private static List<Order.API.Models.Order> orders;
        public FakeDataSource()
        {
            orders = new List<Models.Order> {
                new Models.Order(){ Id=1, CustomerId="abc", TotalPrice=500},
                new Models.Order(){ Id=2, CustomerId="xyz", TotalPrice=750},
                new Models.Order(){ Id=3, CustomerId="def", TotalPrice=1500},
            };


        }

        public async Task<IEnumerable<Models.Order>> GetOrdersAsync() => await Task.FromResult(orders);

        public async Task AddOrder(Models.Order order)
        {
            order.Id = ++orders[orders.Count - 1].Id;
            orders.Add(order);
            await Task.CompletedTask;
        }

        public async Task UpdateOrderState(int orderId, OrderState newState)
        {
            var order = orders.Find(x => x.Id == orderId);
            order.OrderState = newState;
            await Task.CompletedTask;
        }
    }
}
