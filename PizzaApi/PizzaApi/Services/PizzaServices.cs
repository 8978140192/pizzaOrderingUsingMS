using PizzaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApi.Services
{
    public class PizzaServices
    {
        private readonly PizzaDetailsContext _context;

        public PizzaServices(PizzaDetailsContext context)
        {
            _context = context;
        }
        
        public IEnumerable<PizzaDetails> GetAllPizzaDetails()
        {
            //IEnumerable<PizzaDetails> pizzaDetails = null;
            //foreach (var item in _context.PizzaDetails)
            //{
            //    pizzaDetails.(item);
            //}
            //return pizzaDetails;
            try
            {
                IList<PizzaDetails> pizzas = _context.PizzaDetails.ToList();
                if (pizzas.Count > 0)
                    return pizzas;
                else
                    return null;
            }
            catch (ArgumentNullException argnulex)
            {
                Console.WriteLine(argnulex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }
        public PizzaDetails GetAllPizzaDetailsById(string Id)
        {
            PizzaDetails pizza = _context.PizzaDetails.FirstOrDefault(u => u.PizzaId == Id);
            return pizza;

        }
    }
}
