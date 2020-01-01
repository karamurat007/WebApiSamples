using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest2.DataAccess;
using WebApiTest2.Entities;

namespace WebApiTest2.Controllers
{
    [Route("api/products")]
    public class ProductsController:Controller
    {
        IProductDal _productDal;
        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet]
        //public string Get()
        //{
        //    return "ProductsController çalıştı.";
        //}
        //12. Ders içeriğinde yapılanlar
        public IActionResult Get()
        {
            var prodct = _productDal.GetList();
            return Ok(prodct);
        }

        //13. Ders içeriğinde yapılanlar
        [HttpGet("{prodctId}")]
        public IActionResult Get(int prodctId)
        {
            try
            {
                var prodct = _productDal.Get(p => p.ProductId == prodctId);
                if (prodct == null)
                {
                    return NotFound($"İstenen {prodctId} nolu ProductId için DB tarafında değer yer almıyor!!!");
                }
                return Ok(prodct);
            }
            catch
            {

            }
            return BadRequest();
        }

        
        [HttpPost]
        /*14. Ders içeriğinde yapılanlar
        public IActionResult Post(Product product)
        {
            return Ok();
        }
        //JSON gönderim şekli sağlandığında veriyi almak için bu tanımlama kullanılır !!!
        //public IActionResult Post([FromBody]Product product)
        //{
        //    return Ok();
        //}
        */

        //15. Ders içeriğinde yapılanlar
        public IActionResult Post(Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(201);
            }
            catch
            {

            }
            return BadRequest();
        }

        //16. Ders içeriğinde yapılanlar
        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch
            {

            }
            return BadRequest();
        }

        //17. Ders içeriğinde yapılanlar
        [HttpDelete("{prodctId}")]
        public IActionResult Delete(int prodctId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = prodctId });
                return Ok();
            }
            catch
            {

            }
            return BadRequest();
        }
    }
}
