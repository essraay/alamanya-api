using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Services;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IJWTAuthenticationManager _jWTAuthenticationManager;
        //IMailService _mailService;

        public UsersController(IUserService userService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _userService = userService;
            _jWTAuthenticationManager = jWTAuthenticationManager;
            //_mailService = mailService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] string email, [FromForm] string password)
        {
            User kullanici = _userService.Get(user => user.Email == email).Data;

            if (kullanici == null)
                return BadRequest(new ErrorResult(Messages.USER_NOT_FOUND));

            if (kullanici.Password != password)
                return BadRequest(new ErrorResult(Messages.USER_WRONG_PASSWORD));

            kullanici.Password = null;

            var token = _jWTAuthenticationManager.Authenticate(email);

            if (token == null) return Unauthorized();

            kullanici.Token = token;

            return Ok(kullanici);
        }


        [AllowAnonymous]
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [AllowAnonymous]
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("updatePassword")]
        public IActionResult UpdatePassword([FromForm] string email, [FromForm] string password, [FromForm] string newPassword)

        {

            var result = _userService.Get(user => user.Email == email).Data;

            if (result.Email == email && result.Password == password)
            {
                result.Password = newPassword;
                _userService.Update(result);
                return Ok(new { message = "Şifre güncelleme başarılı!" });
            }
            return BadRequest(result);

        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {

            var user = _userService.Get(user => user.Email == email).Data;
            var newPassword = FileService.generateRandomString();
            user.Password = newPassword;

            MailRequest mail = new MailRequest()
            {
                ToEmail = user.Email,
                Subject = "Yeni şifreniz",
                Body = newPassword,
            };
            //await _mailService.SendEmailAsync(mail);
            _userService.Update(user);
            return Ok(new { message = "Mail adresinize yeni şifreniz gönderildi." });
        }
    }
}
