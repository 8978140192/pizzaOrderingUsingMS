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
    public class OrderSummaryController : Controller
    {
        private readonly OrderSummaryService _orderSummaryService;

        public OrderSummaryController(OrderSummaryService service)
        {
            _orderSummaryService = service;
        }
        public IActionResult SummaryPage()
        {
            if (CommanUsedValued.customerPizzaDetail.Count()==0)
            {
                return RedirectToAction("PizzaView", "PizzaView");
            }
            if (TempData["token"] != null)
            {
                string token = TempData.Peek("token").ToString();
                TempData.Keep("token");
                ViewBag.prices = _orderSummaryService.PizzaOrderPriceDetails(CommanUsedValued.customerPizzaDetail);
                return View(CommanUsedValued.customerPizzaDetail);

            }

            return RedirectToAction("Login", "UserLogin");

            
            
        }
        public IActionResult ConformOrder()
        {
            if (TempData["token"] != null)
            {
                string token = TempData.Peek("token").ToString();
                TempData.Keep("token");
                _orderSummaryService.UpdateDatabase("SUCESS",token);
                return RedirectToAction("OrderSucessPage", "OrderSummary");

            }
            
            return RedirectToAction("Login", "UserLogin");


            
             
        }
         public IActionResult CancleOrder()
        {

            if (TempData["token"] != null)
            {
                string token = TempData.Peek("token").ToString();
                TempData.Keep("token");
                _orderSummaryService.UpdateDatabase("FAIL",token);
                return RedirectToAction("PizzaView", "PizzaView");

            }

            return RedirectToAction("Login", "UserLogin");


            
             
        }
        public IActionResult OrderSucessPage()
        {
            //if (CommanUsedValued.orderQuatity<1)
            //{
            //    return RedirectToAction("PizzaView", "PizzaView");

            //}
            if (CommanUsedValued.CurrentOrderId == 0)
            {
                ViewBag.orderApiServer = CommanUsedValued.User.UserName +" our server's down we are working on it.....";
                ViewBag.user = CommanUsedValued.User;
                return View();
            }
            ViewBag.orderApiServer = CommanUsedValued.User.UserName + " YOUR ORDER PLACED SUCCESFULLY ORDER ID "+ CommanUsedValued.CurrentOrderId;
            ViewBag.user = CommanUsedValued.User;
            return View();
        }
    }
}
