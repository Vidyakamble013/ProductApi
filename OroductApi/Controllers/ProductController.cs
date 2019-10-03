using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]
        public IList<BulkUpdate> GetProduct()
        {
            var result = this.productManager.GetProduct();
            if(result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        [HttpPost]
        public IActionResult AddProducts(BulkUpdate bulkUpdate)
        {
            var result = this.productManager.AddProduct(bulkUpdate);
            if(result!= null)
            {
                return this.Ok(new { result });
            }
            else
            {
               return  this.BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(IList<BulkUpdate> productNumber, string status)
        {
            var result = this.productManager.MultipleUpdate(productNumber, status);
            if(result!= null)
            {
                return this.Ok(new { result });
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}