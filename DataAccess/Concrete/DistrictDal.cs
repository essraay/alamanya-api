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
    public class DistrictDal : EfEntityRepositoryBase<District, AlmanyaContext>, IDistrictDal
    {
        public District GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.District.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
