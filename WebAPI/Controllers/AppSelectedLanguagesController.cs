﻿using Business.Abstract;
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
    public class AppSelectedLanguagesController : ControllerBase
    {
        IAppSelectedLanguageService _appSelectedLanguageService;
        public AppSelectedLanguagesController(IAppSelectedLanguageService appSelectedLanguageService)
        {
            _appSelectedLanguageService = appSelectedLanguageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _appSelectedLanguageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _appSelectedLanguageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}