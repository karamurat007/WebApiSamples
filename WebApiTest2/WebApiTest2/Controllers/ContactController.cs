using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest2.Models;

namespace WebApiTest2.Controllers
{
    [Route("api/[controller]")]
    public class ContactController:Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel{Id = 1, FirstName="Ayhan Bahadır", LastName="Meriç"}
            };
        }
    }
}
