using System;
using System.Collections.Generic;
using ToolStore.Domain.Models;

namespace ToolStore.Domain.Models
{
    public class Order : Entity
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public List<Tool> Tools { get; set; }

        public bool IsAlreadyCancelled()
        {
            return Status.Contains("CANCELLED", StringComparison.InvariantCultureIgnoreCase);
        }

        public void SetCancelledStatus()
        {
            Status = "CANCELLED";
        }

        public void SetNewOrderStatus()
        {
            Status = "NEW_ORDER";
        }

        public void SetTotalAmount(double amount)
        {
            TotalAmount = amount;
        }
    }
}