using Business.Abstract;
using ClosedXML.Excel;
using Core.Entities.Concrete;
using Core.Services;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormsController : ControllerBase
    {
        IApplicationFormService _formService;
        IMailService _mailService;

        public ApplicationFormsController(IApplicationFormService formService, IMailService mailService)
        {
            _formService = formService;
            _mailService = mailService;
        }

        //string category
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync(
            string gender,
            string dualNationality,
            string nationality,
            string ageRange,
            string germanLevel,
            string subCategory,
            string category,
            string province,
            string balance
        )
        {
            var result = _formService.GetAll(x =>
                (gender != null ? x.GenderId.ToString() == gender : true) &&
                (dualNationality != null ? x.DualNationality.ToString() == dualNationality : true) &&
                (nationality != null ? x.NationalityId.ToString() == nationality : true) &&
                (ageRange != null ? x.AgeRangeId.ToString() == ageRange : true) &&
                (germanLevel != null ? x.GermanLevelId.ToString() == germanLevel : true) &&
                (subCategory != null ? x.SubCategoryId.ToString() == subCategory : true) &&
                (category != null ? x.CategoryId.ToString() == category : true) &&
                (province != null ? x.ProvincesId.ToString() == province : true) &&
                (balance != null ? x.BalanceId.ToString() == balance : true) &&
                x.IsActive

            );
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        //string category
        [HttpGet("export")]
        public async Task<IActionResult> Export(
            string gender,
            string dualNationality,
            string nationality,
            string ageRange,
            string germanLevel,
            string subCategory,
            string category,
            string province,
            string balance
        )
        {
            //MailRequest mailRequest = new() { ToEmail = "170541071@firat.edu.tr", Subject = "En Personal Başvuru Formu", Body = "Başvurunuz bize ulaşmıştır." };

            //await _mailService.SendEmailAsync(mailRequest);
            var result = _formService.GetAll(x =>
                (gender != null ? x.GenderId.ToString() == gender : true) &&
                (dualNationality != null ? x.DualNationality.ToString() == dualNationality : true) &&
                (nationality != null ? x.NationalityId.ToString() == nationality : true) &&
                (ageRange != null ? x.AgeRangeId.ToString() == ageRange : true) &&
                (germanLevel != null ? x.GermanLevelId.ToString() == germanLevel : true) &&
                (subCategory != null ? x.SubCategoryId.ToString() == subCategory : true) &&
                (category != null ? x.CategoryId.ToString() == category : true) &&
                (province != null ? x.ProvincesId.ToString() == province : true) &&
                (balance != null ? x.BalanceId.ToString() == balance : true)
            );
            if (!result.Success) return BadRequest(result.Message);

            var dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("Adı", typeof(string));
            dataTable.Columns.Add("Soyadı", typeof(string));
            dataTable.Columns.Add("Cinsiyet", typeof(string));
            dataTable.Columns.Add("Yaş Aralığı", typeof(string));
            dataTable.Columns.Add("Kategori", typeof(string));
            dataTable.Columns.Add("Meslek", typeof(string));
            dataTable.Columns.Add("Almanca Dil Seviyesi", typeof(string));
            dataTable.Columns.Add("Uyruk", typeof(string));
            dataTable.Columns.Add("İl", typeof(string));
            dataTable.Columns.Add("Denklik", typeof(string));


            result.Data.ForEach(item =>
            {
                dataTable.Rows.Add(
                    item.Name, 
                    item.Surname,
                    item.Gender.Name, 
                    item.AgeRange.Range,
                    item.SubCategory.Name,
                    item.Category.CategoryName, 
                    item.GermanLevel.Level,
                    item.Nationality.Name,
                    item.Provinces.Name,
                    item.Balance.Name
                );
            });


            // export as xlsx
            string FILE_PATH = Path.Combine("StaticFiles", "exports", FileService.generateRandomString() + ".xlsx");
            string status = "FAIL";

            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Başvurular");
                worksheet.Cell(1, 1).Value = "Adı";
                worksheet.Cell(1, 2).Value = "Soyadı";
                worksheet.Cell(1, 3).Value = "Cinsiyeti";
                worksheet.Cell(1, 4).Value = "Yaş Aralığı";
                worksheet.Cell(1, 5).Value = "Kategori";
                worksheet.Cell(1, 6).Value = "Meslek";
                worksheet.Cell(1, 7).Value = "Almanca Dil Seviyesi";
                worksheet.Cell(1, 8).Value = "Uyruk";
                worksheet.Cell(1, 9).Value = "İl";
                worksheet.Cell(1, 10).Value = "Denklik";
  


                worksheet.Cell("A2").InsertData(dataTable);

                var table = worksheet.Range(1, 1, dataTable.Rows.Count, dataTable.Columns.Count).CreateTable();
                table.Resize(1, 1, table.RowCount() + 1, table.ColumnCount());

                workbook.SaveAs(Path.Combine("wwwroot", FILE_PATH));
                status = "OK";
            }

            return Ok(new
            {
                path = FILE_PATH,
                status = status
            });
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
        public async Task<IActionResult> AddAsync([FromForm] ApplicationFormDto dto)
        {
            MailRequest mailRequest = new()
            {
                ToEmail = dto.applicationForm.Email,
                Subject = "En Personal GMBH Başvuru Formu",
                Body = "<body width=\"100%\" style=\"margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;\"><link rel=\"stylesheet\" href=\"https://enpersonalgmbh.com/posta.css\"><center style=\"width: 100%; background-color: #f1f1f1;\"> <div style=\"display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;\"> &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp; </div><div style=\"max-width: 600px; margin: 0 auto;\" class=\"email-container\"> <table align=\"center\" role=\"presentation\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" style=\"margin: auto;\"> <tr> <td valign=\"top\" class=\"bg_white\" style=\"padding: 1em 2.5em 0 2.5em;\"> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td class=\"logo\" style=\"text-align: center;\"> <h1><img src=\"https://enpersonalgmbh.com/assets/img/logo.png\" alt=\"\"></h1> </td></tr></table> </td></tr><tr> <td valign=\"middle\" class=\"hero bg_white\" style=\"padding: 2em 0 4em 0;\"> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"> <tr> <td style=\"text-align: center;\"> <div class=\"text-author\"> <img src=\"https://enpersonalgmbh.com/basarili.png\" alt=\"\" style=\"width: 100px; max-width: 600px; height: auto; margin: auto; display: block;\"> <h3 class=\"name\">Başvurunuz bize ulaşmıştır</h3> <h5><a href=\"#\" class=\"btn btn-primary\">Başvurunuz tamamlanmıştır</a></h5> <span class=\"position\">Ekibimiz en kısa süre içerisinde sizin ile iletişime geçicektir.</span> <p><a href=\"https://www.enpersonalgmbh.com\" class=\"btn-custom\">Web Sitemiz</a></p></div></td></tr></table> </td></tr></table> </div></center></body>"
            };

            //await _mailService.SendEmailAsync(mailRequest);
            //dto.applicationForm.CvFile = await FileService.UploadFile(dto.dvFile);
            //dto.applicationForm.ContractFile = await FileService.UploadFile(dto.contractFile);

            if (dto.cvFile != null)
            {
                dto.applicationForm.CvFile = await FileService.UploadFile(dto.cvFile);
            }

            if (dto.contractFile != null)
            {
                dto.applicationForm.ContractFile = await FileService.UploadFile(dto.contractFile);
            }

            if (dto.otherFile != null)
            {
                dto.applicationForm.OtherFile = await FileService.UploadFile(dto.otherFile);
            }

            dto.applicationForm.CreatedAt = DateTime.Now;

            var result = _formService.Add(dto.applicationForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("disable")]
        public IActionResult Update(ApplicationForm applicationForm)
        {
            var existingForm = _formService.GetById(applicationForm.Id).Data;
            existingForm.IsActive = false;
            var result = _formService.Update(existingForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
