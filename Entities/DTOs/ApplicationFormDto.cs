using Core;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ApplicationFormDto : IDto
    {
        public ApplicationForm applicationForm { get; set; }
        public IFormFile cvFile { get; set; }
        public IFormFile contractFile { get; set; }
        public IFormFile otherFile { get; set; }
    }
}
