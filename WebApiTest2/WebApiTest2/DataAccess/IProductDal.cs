using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest2.Entities;

namespace WebApiTest2.DataAccess
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
