using Business.Abstract;
using Core.Services;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class ApplicationFormsController : ControllerBase
    {
        IApplicationFormService _formService;

        public ApplicationFormsController(IApplicationFormService formService)
        {
            _formService = formService;
        }

        //string category
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _formService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetAllById(int id)
        {
            var result = _formService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromForm] ApplicationForm form,
            IFormFile cvFile, IFormFile contractFile, IFormFile otherFile
            )
        {
            form.CvFile = await FileService.UploadFile(cvFile);
            form.ContractFile = await FileService.UploadFile(contractFile);
            if(otherFile != null)
            {
                form.OtherFile = await FileService.UploadFile(otherFile);
            }

            var result = _formService.Add(form);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ApplicationForm form)
        {
            var result = _formService.Delete(form);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
