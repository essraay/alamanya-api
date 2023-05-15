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
    public class OtherLanguagesController : ControllerBase
    {
        IOtherLanguageService _otherLanguageService;

        public OtherLanguagesController(IOtherLanguageService otherLanguageService)
        {
            _otherLanguageService = otherLanguageService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _otherLanguageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
