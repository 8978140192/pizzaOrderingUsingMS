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
    public class UserLoginController : Controller
    {
        private readonly UserService _userService;

        public UserLoginController(UserService service)
        {
            _userService = service;
        }
        public IActionResult RegisterPage()
        {
            return View();
        }


        [HttpPost]
        
        public IActionResult RegisterPage(UserDetail userDetail)
        {
            try
            {
                if (userDetail.Password != userDetail.ReTyptePassword)
                {
                    ViewBag.Error = "Password not matched";
                    return View();
                }
                UserDetail user = _userService.Register(userDetail);
                if (user != null)
                {
                    
                    return RedirectToAction("StartPage", "StartUpPage");
                }
            }
            catch
            {
                ViewBag.Error = "Not Registered";
                return View();
            }
            ViewBag.Error = "Not Registered";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        ////// POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginDTO userDto)
        {
           try
            {
                UserDTO userss = _userService.Login(userDto);
                if (userss != null)
                {
                    TempData["token"] = userss.jwtToken;
                    return RedirectToAction("PizzaView", "PizzaView");
                }
            }
            catch
            {
                
                return View();
            }
            ViewBag.Error = "Invalid username or password";
           return View();
        }

        public IActionResult LogOut(string button)
        {
            if (TempData["token"] != null)
            {
                TempData["token"] = null;

            }
            //_pizzaViewService.InserIntoOrders(button);
            return RedirectToAction("Login", "UserLogin");
        }
    }
}
