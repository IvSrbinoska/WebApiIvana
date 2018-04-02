using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiIvana.Models;

namespace WebApiIvana.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };


        List<Product> productsList = new List<Product>
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };


        public IEnumerable<Product> GetAllProducts()
        {
            //return products;
            return productsList;
        }

        public IHttpActionResult GetProduct(int id)
        {
            //var product = products.FirstOrDefault((p) => p.Id == id);
            var product = productsList.Find(b => b.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPut]
        public HttpResponseMessage Update(long id, [FromBody] Product item)
        {
            if (item == null || item.Id != id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "bad request");
            }
            var a = productsList.Find(p => p.Id == item.Id);
            if(a == null){
                // err
                return Request.CreateResponse(HttpStatusCode.NotFound, "ne postoi"); 
            }
            else{
                // zapisi vo baza
                
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent, "update zavrsen");
            return response;
        }


        //[HttpPost]
        //public HttpResponseMessage Add(long id, [FromBody] Product item)
        //{
        //    if (item == null || item.Id != id)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, "bad request");
        //    }
        //    var a = productsList.Find(p => p.Id == item.Id);
        //    if (a == null)
        //    {
        //        // err
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "ne postoi");
        //    }
        //    else
        //    {
        //        // zapisi vo baza

        //    }
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent, "update zavrsen");
        //    return response;
        //}
    }
}
