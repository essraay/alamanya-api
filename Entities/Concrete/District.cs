using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvincesId { get; set; }
        public Provinces Provinces { get; set; }
    }
}
