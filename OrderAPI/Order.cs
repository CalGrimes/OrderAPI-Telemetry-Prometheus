namespace TelemetryPrometheus
{
    public class Order
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int StoreId { get; set; }

        public int Quantity { get; set; }
    }
}
