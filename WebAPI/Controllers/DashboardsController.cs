using Business.Abstract;
using DataAccess.Concrete;
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
    public class DashboardsController : ControllerBase
    {
        IApplicationFormService _applicationFormService;
        ICategoryService _categoryService;
        IUserService _userService;
        public DashboardsController(
            IApplicationFormService applicationFormService,
            IUserService userService,
            ICategoryService categoryService
            )
        {
            _applicationFormService = applicationFormService;
            _categoryService = categoryService;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet("")]
        public IActionResult Get()
        {
            using (var context = new AlmanyaContext())
            {
                var applicationFormCount = context.ApplicationForm.Count();
                var categoryCount = context.Category.Count();
                var userCount = context.User.Count();
          


                return Ok(new
                {
                    applicationFormCount = applicationFormCount,
                    categoryCount = categoryCount,
                    userCount = userCount,
                });
            }

        }
    }
}
