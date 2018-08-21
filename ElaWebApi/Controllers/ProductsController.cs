using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElaWebApi.Models;

namespace ElaWebApi.Controllers
{
	public class ProductsController : ApiController
	{
		List<Product> products = new List<Product>
		{
			new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
			new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
			new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
		};

        [HttpGet]
        [ActionName("GetAllProducts")]
		public IEnumerable<Product> GetProducts()
		{
			return products;
		}

        [HttpGet]
        [ActionName("GetProduct")]
		public IHttpActionResult GetSingleProduct(int id)
		{
			var product = products.FirstOrDefault((p) => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

        [HttpDelete]
        [ActionName("DeleteProduct")]
        public IHttpActionResult DeleteSingleProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);

            return Ok(product);
        }

        public void SaveProduct(string Name, string Category, int Price)
        {
            var maxProdId = products.Max(t => t.Id);

            products.Add(new Product
            {
                Id = maxProdId + 1,
                Name = Name,
                Category = Category,
                Price = Price
            });
        }

        [NonAction]
        public void DontCallMeFunction()
        {
            //Not implemented
        }
	}
}
