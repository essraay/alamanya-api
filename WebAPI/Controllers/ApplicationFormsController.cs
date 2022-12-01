using Business.Abstract;
using Core.Entities.Concrete;
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
        //IMailService _mailService

        public ApplicationFormsController(IApplicationFormService formService, IUserService userService
            //IMailService mailService
            )
        {
            _formService = formService;
            //_mailService = mailService;
        }

        //string category
        [HttpGet("getall")]
        public IActionResult GetAll(
            string gender, 
            string dualNationality, 
            string nationality, 
            string ageRange, 
            string germanLevel,
            string category,
            string province
        )
        {
            var result = _formService.GetAll(x => 
                (gender != null ? x.GenderId.ToString() == gender : true) &&
                (dualNationality != null ? x.DualNationality.ToString() == dualNationality : true) &&
                (nationality != null ? x.NationalityId.ToString() == nationality : true) &&
                (ageRange != null ? x.AgeRangeId.ToString() == ageRange : true) &&
                (germanLevel != null ? x.GermanLevelId.ToString() == germanLevel : true) &&
                (category != null ? x.CategoryId.ToString() == category : true) &&
                (province != null ? x.ProvincesId.ToString() == province : true)
            );
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
            if (otherFile != null)
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
