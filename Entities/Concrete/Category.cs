using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }

        //public List<ApplicationForm> ApplicationForms { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
