using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Services
{
    public class OrderService
    {
        public string UpdateOrderTable(OrderDTO orderDTO)
        {
            try
            {
                int orderId = 0;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1909/api/");
                    var postTask = client.PostAsJsonAsync<OrderDTO>("order", orderDTO);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<int>();
                        //data.Wait();
                        orderId = data.Result;

                    }
                }
                return Convert.ToString(orderId);
            }
            catch (Exception)
            {

                return null;
            }
            //UserLoginDTO userDTO = null;
            
        }

        public void UpdateOrderDetailTable(List<CustomerPizzaDetailsDTO> customerPizzaDetailsDTO)
        {
            //UserLoginDTO userDTO = null;
            //int orderId = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1909/api/");
                var postTask = client.PostAsJsonAsync<List<CustomerPizzaDetailsDTO>>("order/orderDetail", customerPizzaDetailsDTO);
                postTask.Wait();
                var result = postTask.Result;
                
            }
            //return Convert.ToString(orderId);
        }
    }
}
