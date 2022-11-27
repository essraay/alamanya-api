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
    public class GenderDal : EfEntityRepositoryBase<Gender, AlmanyaContext>, IGenderDal
    {
        public Gender GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.Gender.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
