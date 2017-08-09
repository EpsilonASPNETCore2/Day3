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
    }
}
