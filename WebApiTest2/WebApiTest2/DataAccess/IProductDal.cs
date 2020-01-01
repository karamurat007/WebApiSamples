using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest2.Entities;
using WebApiTest2.Models;

namespace WebApiTest2.DataAccess
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductModel> GetProductsWithDetails();
    }
}
