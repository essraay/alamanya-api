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
    public class SubCategoryDal : EfEntityRepositoryBase<SubCategory, AlmanyaContext>, ISubCategoryDal
    {
         public List<SubCategory> GetAll(Expression<Func<SubCategory, bool>> filter = null)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                return filter == null ? context.Set<SubCategory>().Include(item => item.Category).ToList() :
                    context.Set<SubCategory>().Where(filter).Include(item => item.Category).ToList();
            }
            
        }
        
        public SubCategory GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                return context.Set<SubCategory>()
                    .Include(app => app.Category).Where(app => app.Id == id).SingleOrDefault();
            }
        }
    }
}
