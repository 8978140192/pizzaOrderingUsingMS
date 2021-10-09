using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderDto
    {
        public string userId { get; set; }
        public double deliveryCharge { get; set; }
        public double totalBill { get; set; }
        public int qty { get; set; }
        public string status { get; set; }
    }
}
