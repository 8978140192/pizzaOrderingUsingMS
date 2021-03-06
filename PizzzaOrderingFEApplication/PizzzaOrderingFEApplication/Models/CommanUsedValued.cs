using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Models
{
    public class CommanUsedValued
    {
        
        public static string CurrentUsser { get; set; }
        public static UserDTO User { get; set; }
        public static int CurrentOrderId { get; set; }
        
        public static double orderTotalBill { get; set; }
        public static double orderDeliveryCharges = 25;

        public static int orderQuatity { get; set; }
        
        public static List<string> pizzaIdOfCustomer = new();
        public static List<CustomerPizzaDetails> customerPizzaDetail = new();
    }
}
