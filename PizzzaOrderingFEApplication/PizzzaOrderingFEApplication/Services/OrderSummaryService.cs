using PizzzaOrderingFEApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Services
{
    public class OrderSummaryService
    {
        public List<double> PizzaOrderPriceDetails(List<CustomerPizzaDetails> customerPizzaDetails)
        {
            List<double> pizzaOrderPrices = new();
            int pizzaPrice = 0;
            CommanUsedValued.orderTotalBill = 0;
            CommanUsedValued.orderQuatity = 0;
            //int totalPrice = 0;
            foreach (var item in customerPizzaDetails)
            {
                pizzaPrice = (int)item.pizzaDetail.PizzaPrice * item.qty;
                if (item.onion == true)
                    pizzaPrice += 60 * item.qty;
                if (item.GrilledMushroom == true)
                    pizzaPrice += 60 * item.qty;
                if (item.crispCapsicum == true)
                    pizzaPrice += 60 * item.qty;
                pizzaOrderPrices.Add(pizzaPrice);
                CommanUsedValued.orderTotalBill += pizzaPrice;
                if (item.qty !=0)
                {
                    CommanUsedValued.orderQuatity += 1;
                }
            }
            pizzaOrderPrices.Add(CommanUsedValued.orderTotalBill);
            return pizzaOrderPrices;
        }

        public void UpdateDatabase(string status,string token)
        {
             OrderDTO orderDTO = new();
            try
            {
                orderDTO.userId = CommanUsedValued.User.UserId;
                orderDTO.totalBill = CommanUsedValued.orderTotalBill;
                if (CommanUsedValued.orderTotalBill > 250)

                    orderDTO.deliveryCharge = 0;

                else
                    orderDTO.deliveryCharge = 25;
                orderDTO.qty = CommanUsedValued.orderQuatity;
                orderDTO.status = status;
                int currentOrderId = InsertIntoOrderTable(orderDTO, token);
                CommanUsedValued.CurrentOrderId = currentOrderId;
                InsertIntoOrderDetailTable(currentOrderId, token);
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void InsertIntoOrderDetailTable(int currentOrderId,string token)
        {
            List<OrderDetailsDTO> details = new();
            foreach (var item in CommanUsedValued.customerPizzaDetail)
            {
                OrderDetailsDTO orderDetailsDTO = new();
                orderDetailsDTO.orderId = currentOrderId;
                orderDetailsDTO.pizzaId = item.pizzaId;
                orderDetailsDTO.qty = item.qty;
                orderDetailsDTO.GrilledMushroom = item.GrilledMushroom;
                orderDetailsDTO.crispCapsicum = item.crispCapsicum;
                orderDetailsDTO.onion = item.onion;
                details.Add(orderDetailsDTO);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = client.PostAsJsonAsync<List<OrderDetailsDTO>>("Order/orderDetail", details);
                postTask.Wait();
                var result = postTask.Result;
                
            }
            CommanUsedValued.customerPizzaDetail.Clear();
            CommanUsedValued.pizzaIdOfCustomer.Clear();
            CommanUsedValued.orderQuatity = 0;
            CommanUsedValued.orderTotalBill=0;
        }

        public string InsertIntoOrderTables(OrderDTO orderDTO,string token)
        {

            string ordersId = null;
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
                var getTask = client.GetAsync("Order");

                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var data = result.Content.ReadAsStringAsync();
                    var data = result.Content.ReadFromJsonAsync<string>();
                    data.Wait();
                    ordersId = data.Result;

                }
            }
            return ordersId;
        }

        public int InsertIntoOrderTable(OrderDTO orderDTO,string token)
        {
            //UserLoginDTO userDTO = null;
            int orderId = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = client.PostAsJsonAsync<OrderDTO>("Order", orderDTO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<int>();
                    //data.Wait();
                    orderId = data.Result;

                }
            }
            return orderId;
        }

    }
}
