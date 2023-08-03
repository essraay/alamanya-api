using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProvincesDal : EfEntityRepositoryBase<Provinces, AlmanyaContext>, IProvincesDal
    {
        public List<Provinces> GetAll(Expression<Func<Provinces, bool>> filter = null)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                return filter == null ? context.Set<Provinces>().Include(item => item.Districts).ToList() :
                    context.Set<Provinces>().Where(filter).Include(item => item.Districts).ToList();
            }      
        }
        
        public Provinces GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                return context.Set<Provinces>()
                    .Include(app => app.Districts).Where(app => app.Id == id).SingleOrDefault();
            }
        }
    }
} 
