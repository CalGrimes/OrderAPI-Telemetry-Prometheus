namespace TelemetryPrometheus
{
    public class OrderRepository
    {
        public List<Order> GetOrders()
        {
            return new List<Order>();
        }

        public Order AddOrder(int userId, Product product, int storeId, int quantity)
        {
            Order newOrder = new Order
            {
                Id = Guid.NewGuid(),
                Product = product,
                StoreId = storeId,
                Quantity = quantity
            };

            return newOrder;
        }

        public async Task SaveAsync()
        {
            await Task.CompletedTask;
        }
    }
}
