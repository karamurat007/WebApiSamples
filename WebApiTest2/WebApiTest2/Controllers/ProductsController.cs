using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest2.Controllers
{
    [Route("api/products")]
    public class ProductsController:Controller
    {
        [HttpGet]
        public string Get()
        {
            return "ProductsController çalıştı.";
        }
    }
}
