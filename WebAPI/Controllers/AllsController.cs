using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllsController : ControllerBase
    {
        IApplicationFormService _applicationFormService;

        public AllsController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            using (var context = new AlmanyaContext())
            {
                return Ok(new
                {
                   
                });
            }
        }
    }
}
