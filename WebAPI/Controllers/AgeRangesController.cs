using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeRangesController : ControllerBase
    {
        IAgeRangeService _ageRangeService;
        public AgeRangesController(IAgeRangeService ageRangeService)
        {
            _ageRangeService = ageRangeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ageRangeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ageRangeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
