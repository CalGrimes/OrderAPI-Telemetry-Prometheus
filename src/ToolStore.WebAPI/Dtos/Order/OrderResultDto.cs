using ToolStore.Domain.Models;

namespace ToolStore.WebApi.Dtos.Order
{
    public class OrderResultDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string City { get; set; }

        public string Status { get; set; }

        public string TotalAmount { get; set; }

        public IEnumerable<Domain.Models.Tool> Tools { get; set; }
    }
}