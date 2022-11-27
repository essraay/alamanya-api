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
    public class GermanLanguageLevelsController : ControllerBase
    {
        IGermanLanguageLevelService _germanLanguageLevelService;
        public GermanLanguageLevelsController(IGermanLanguageLevelService germanLanguageLevelService)
        {
            _germanLanguageLevelService = germanLanguageLevelService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _germanLanguageLevelService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _germanLanguageLevelService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
