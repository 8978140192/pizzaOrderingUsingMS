using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Services
{
    public class PizzaViewService
    {
        public async Task<IEnumerable<PizzaViewDTO>> GetPizzaDetails()
        {
            IList<PizzaViewDTO> pizzaDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61718/api/");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("PizzaApi");

                //getTask.Wait();
                //var result = getTask.Result;
                if (getTask.IsSuccessStatusCode)
                {
                    //var data = result.Content.ReadAsStringAsync();
                    var data = getTask.Content.ReadFromJsonAsync<IList<PizzaViewDTO>>();
                    data.Wait();
                    pizzaDetail = data.Result;

                }
            }
            return pizzaDetail;
        }
         public async Task<PizzaViewDTO> GetPizzaDetailsById(string id)
        {
            PizzaViewDTO pizzaDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61718/api/");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string api = "PizzaApi/" + id;
                var getTask = await client.GetAsync(api);

                //getTask.Wait();
                //var result = getTask.Result;
                if (getTask.IsSuccessStatusCode)
                {
                    //var data = result.Content.ReadAsStringAsync();
                    var data = getTask.Content.ReadFromJsonAsync<PizzaViewDTO>();
                    data.Wait();
                    pizzaDetail = data.Result;

                }
            }
            return pizzaDetail;
        }

        
    }
}
