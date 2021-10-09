using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Services
{
    public class OrderService
    {
        private readonly PizzaOrderOrderApiContext _context;


        public OrderService(PizzaOrderOrderApiContext context)
        {
            _context = context;

        }

        public string UpdateOrderTable(OrderDto orderDto)
        {
            Order order = new();
            order.UserId = orderDto.userId;
            order.DeliveryCharges = orderDto.deliveryCharge;
            order.TotalBill = orderDto.totalBill;
            order.Quatity = orderDto.qty;
            order.OrderStatus = orderDto.status;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Convert.ToString(order.OrderId);
        }

        public void UpdateOrderDetailTable(List<CustomerPizzaDetailsDTO> customerPizzaDetailsDTO)
        {
            foreach (var item in customerPizzaDetailsDTO)
            {
                for (int i = 0; i < item.qty; i++)
                {
                    int orderDetailId = InserIntoOrderDetail(item.orderId,item.pizzaId);
                    if (item.onion == true)
                    {
                        
                        InserIntoTopping(orderDetailId, "1");
                    }
                    if (item.crispCapsicum == true)
                    {
                        
                        InserIntoTopping(orderDetailId, "2");
                    }
                    if (item.GrilledMushroom == true)
                    {
                        
                        InserIntoTopping(orderDetailId, "3");

                    }
                }

            }

        }

        private void InserIntoTopping(int orderDetailId, string toppindId)
        {
            OrderToppingDetail orderToppingDetail = new();
            orderToppingDetail.ItemId = orderDetailId;
            orderToppingDetail.ToppingId = toppindId;
            _context.OrderToppingDetails.Add(orderToppingDetail);
            _context.SaveChanges();

        }

        private int InserIntoOrderDetail(int orderId, string pizzaId)
        {
            OrderDetail orderDetail = new();
            orderDetail.OrderId = orderId;
            orderDetail.PizzaId = pizzaId;
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail.ItemId;
        }
    }
}
