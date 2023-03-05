using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LachaGarden.Controllers
{
    public class LoginController : Controller
    {
        private readonly lachagardenContext db;

        public IActionResult Login()
        {
            return View();
        }

        //[Route("login")]
        [HttpPost]
        public IActionResult CheckLogin(string gmail, string password)
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            var account = ReadJson.GetAdmin();
            bool isCustomer = false;

            var customers = customerRepository.GetCustomers();
            if (gmail != null && password != null)
            {
                if (gmail.Equals(account.Gmail) && password.Equals(account.Password))
                {//admin
                    var member = new Customer
                    {
                        Gmail = account.Gmail,
                        Password = account.Password,
                    };
                    HttpContext.Session.SetString("isAdmin", "true");
                    isCustomer = true;
                    return RedirectToAction("Index", "Home");
                }
                foreach (var i in customers)
                {
                    if (i.Gmail.Equals(gmail) && i.Password.Equals(password))
                    {
                        isCustomer = true;
                        HttpContext.Session.SetString("isAdmin", "false");
                        HttpContext.Session.SetInt32("id", i.Id);
                        return RedirectToAction("Index", "Customer");

                    }
                }
                if (isCustomer == true)
                {
                    ViewBag.error = "Invalid Account";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.error = "Wrong username/email or pass word, please try again";
                    return RedirectToAction("Login", "Login");

                }
            }
            else
            {

                ViewBag.error = "Please Enter your username and password";
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ACCOUNT");
            return RedirectToAction("Index");
        }
    }
}
