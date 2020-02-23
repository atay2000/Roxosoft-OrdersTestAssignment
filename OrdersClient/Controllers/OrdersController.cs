using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrdersClient.Helper;
using OrdersClient.Models;

namespace OrdersClient.Controllers
{
    public class OrdersController : Controller
    {
        private OrdersWebAPI _api = new OrdersWebAPI();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            List<Order> orders = new List<Order>();
            HttpClient apiClient = _api.Initial();
            HttpResponseMessage res = await apiClient.GetAsync("api/orders");

            if (res.IsSuccessStatusCode)
            {
                var resultStr = res.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<Order>>(resultStr);
            }
            
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Order orderDetails = null;
            HttpClient apiClient = _api.Initial();
            HttpResponseMessage res = await apiClient.GetAsync($"api/orders/{id}");

            if (res.IsSuccessStatusCode)
            {
                var resultStr = res.Content.ReadAsStringAsync().Result;
                orderDetails = JsonConvert.DeserializeObject<Order>(resultStr);
            }

            return PartialView("_Details", orderDetails);            
        }

        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", feature?.Error);
        }
    }    
}