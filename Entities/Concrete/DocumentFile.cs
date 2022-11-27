using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DocumentFile : IEntity
    {
            public int Id { get; set; }
            public string Path { get; set; }
            public int ApplicationFormId { get; set; }
    }
}
