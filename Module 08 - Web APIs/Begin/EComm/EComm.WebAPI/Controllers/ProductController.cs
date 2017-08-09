using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EComm.Data;

namespace EComm.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        public DataContext EcommDataContext { get; }
        public ProductController(DataContext dataContext)
        {
            EcommDataContext = dataContext;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get() => EcommDataContext.Products.ToList();

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return EcommDataContext.Products.SingleOrDefault(p => p.Id == id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            EcommDataContext.Products.Add(product);
            EcommDataContext.SaveChanges();
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            if (product == null || product.Id != id) return;

            var existing = EcommDataContext.Products.SingleOrDefault(p => p.Id == id);
            if (existing == null) return;

            existing.ProductName = product.ProductName;
            existing.UnitPrice = product.UnitPrice;
            existing.Package = product.Package;
            existing.IsDiscontinued = product.IsDiscontinued;
            existing.SupplierId = product.SupplierId;
            EcommDataContext.SaveChanges();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existing = EcommDataContext.Products.SingleOrDefault(p => p.Id == id);
            EcommDataContext.Remove(existing);
            EcommDataContext.SaveChanges();
        }
    }
}
