using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppSelectedLanguage : IEntity
    {
        public int Id { get; set; }
        public int ApplicationFormId { get; set; }
        public int OtherLanguageId { get; set; }

        public virtual ApplicationForm ApplicationForm { get; set; }
        public virtual OtherLanguage OtherLanguage { get; set; }

    }
}
