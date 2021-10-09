using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApi.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public double? DeliveryCharges { get; set; }
        public double? TotalBill { get; set; }
        public int? Quatity { get; set; }
        public string OrderStatus { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
