using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzzaOrderingFEApplication.Models;
using PizzzaOrderingFEApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Controllers
{
    public class PizzaViewController : Controller
    {
        private readonly PizzaViewServices _pizzaViewService;

        public PizzaViewController(PizzaViewServices service)
        {
            _pizzaViewService = service;
        }
        public IActionResult PizzaView()
        {
            if (TempData["token"] != null)
            {
                string token = TempData.Peek("token").ToString();
                TempData.Keep("token");
                return View(_pizzaViewService.GetPizzaDetails(token));

            }
            else
                ViewBag.authorize = "UnAuthorized plese login to order pizza";
            return RedirectToAction("Login", "UserLogin");
        }

        public IActionResult check(string button)
        {
            if (TempData["token"] != null)
            {
                string token = TempData.Peek("token").ToString();
                TempData.Keep("token");
                _pizzaViewService.InserIntoOrders(button,token);
                return RedirectToAction("PizzaView");

            }
            //_pizzaViewService.InserIntoOrders(button);
            return RedirectToAction("Login", "UserLogin");
        }

        public IActionResult DeletPizza()
        {
            string pizzaId = TempData.Peek("pizzaid").ToString();
            int pizzaNumber =Convert.ToInt32(pizzaId);
            CommanUsedValued.customerPizzaDetail.RemoveAt(pizzaNumber);
            CommanUsedValued.pizzaIdOfCustomer.RemoveAt(pizzaNumber);


            return RedirectToAction("PizzaDetailsPage");
        }
        public IActionResult PizzaDetailsPage()
        {
            string token = TempData.Peek("token").ToString();
            TempData.Keep("token");
            return View(CommanUsedValued.customerPizzaDetail);
        }
        [HttpPost]
        public IActionResult PizzaDetailsPage(List<CustomerPizzaDetails> customerPizzaDetails)
        {
            if (TempData["token"] != null)
            {
                if (ModelState.IsValid)
                {
                    int count = 0;
                    foreach (var item in customerPizzaDetails)
                    {
                        item.pizzaId = CommanUsedValued.pizzaIdOfCustomer[count];
                        string token = TempData.Peek("token").ToString();
                        TempData.Keep("token");
                        item.pizzaDetail = _pizzaViewService.GetPizzaDetailById(CommanUsedValued.pizzaIdOfCustomer[count],token);
                        count++;
                    }
                    _pizzaViewService.UpdateNewDetails(customerPizzaDetails);
                }

                return RedirectToAction("SummaryPage", "OrderSummary");

            }
            return RedirectToAction("Login", "UserLogin");

        }

        
        
    }
}
