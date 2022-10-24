using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Abc_Company.Models;

namespace Abc_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierAPIController : ControllerBase
    {
        private DBCtx Context { get; }

        public CarrierAPIController(DBCtx _context)
        {
            this.Context = _context;
        }

        [Route("GetCarriers")]
        [HttpGet]
        public List<CarrierModel> GetCarriers(string name)
        {
            return (from c in this.Context.Carriers.Take(10)
                    where c.Address.StartsWith(name) || string.IsNullOrEmpty(name)
                    select c).ToList();
        }
    }
}
