using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryPrometheus.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderRepository _orderRepository;

        public OrderController(ILogger<OrderController> logger, OrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<Guid> Create(int userId, [FromBody] Product product, int storeId, int quantity)
        {
            Order newOrder = _orderRepository.AddOrder(userId, product, storeId, quantity);
            _logger.LogInformation("Order created: {OrderId}", newOrder.Id);

            await _orderRepository.SaveAsync();

            return newOrder.Id;
        }
    }
}