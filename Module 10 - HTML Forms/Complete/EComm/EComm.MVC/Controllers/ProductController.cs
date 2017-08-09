using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.MVC.Controllers
{
    public class ProductController : Controller
    {
        private ECommData ECommData { get; }
        public ProductController(ECommData ecommData)
        {
            ECommData = ecommData;
        }

        public IActionResult Index()
        {
            return View(ECommData.GetProducts());
        }

        public async Task<IActionResult> Async()
        {
            return View("Index", await ECommData.GetProductsAsync());
        }

        public IActionResult Detail(int id)
        {
            return View(ECommData.GetProduct(id));
        }

        [HttpPost]
        public IActionResult AddToCart(int id, int quantity)
        {
            var product = ECommData.GetProduct(id);
            var totalCost = quantity * product.UnitPrice;
            string message = $"You added {product.ProductName} " +
                $"(x{quantity}) to your cart at a total cost of {totalCost:C}.";
            return PartialView("_AddedToCart", message);
        }
    }
}
