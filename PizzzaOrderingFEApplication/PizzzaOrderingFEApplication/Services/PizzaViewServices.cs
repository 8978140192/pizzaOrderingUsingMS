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
    public class PizzaViewServices
    {
        public IEnumerable<PizzaViewDTO> GetPizzaDetails(string token)
        {
            IList<PizzaViewDTO> pizzaDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask =  client.GetAsync("PizzaView");

                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var data = result.Content.ReadAsStringAsync();
                    var data = result.Content.ReadFromJsonAsync<IList<PizzaViewDTO>>();
                    data.Wait();
                    pizzaDetail = data.Result;

                }
            }
            return pizzaDetail;
        }
        public PizzaViewDTO GetPizzaDetailById(string id,string token)
        {
            PizzaViewDTO pizzaDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string api = "PizzaView/" + id;
                var getTask = client.GetAsync(api);

                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var data = result.Content.ReadAsStringAsync();
                    var data = result.Content.ReadFromJsonAsync<PizzaViewDTO>();
                    data.Wait();
                    pizzaDetail = data.Result;

                }
            }
            return pizzaDetail;
        }

        public void InserIntoOrders(string button,string token)
        {
            

            CommanUsedValued.pizzaIdOfCustomer.Add(button);

            CustomerPizzaDetails customerPizzaDetails = new();

            customerPizzaDetails.pizzaDetail = GetPizzaDetailById(button,token);
            customerPizzaDetails.pizzaId = button;
            customerPizzaDetails.onion = false;
            customerPizzaDetails.crispCapsicum = false;
            customerPizzaDetails.GrilledMushroom = false;
            customerPizzaDetails.qty = 1;
            CommanUsedValued.customerPizzaDetail.Add(customerPizzaDetails);
        }

        public void UpdateNewDetails(List<CustomerPizzaDetails> customerPizzaDetails)
        {
            CommanUsedValued.customerPizzaDetail.Clear();
            foreach (var item in customerPizzaDetails)
            {
                CommanUsedValued.customerPizzaDetail.Add(item);
            }
        }
    }
}
