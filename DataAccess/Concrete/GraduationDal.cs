using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GraduationDal : EfEntityRepositoryBase<Graduation, AlmanyaContext>, IGraduationDal
    {
        public Graduation GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.Graduation.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
