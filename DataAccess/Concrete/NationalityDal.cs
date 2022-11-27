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
    public class NationalityDal : EfEntityRepositoryBase<Nationality, AlmanyaContext>, INationalityDal
    {
        public Nationality GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.Nationality.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
