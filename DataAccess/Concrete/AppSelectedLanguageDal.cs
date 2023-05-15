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
    public class AppSelectedLanguageDal : EfEntityRepositoryBase<AppSelectedLanguage, AlmanyaContext>, IAppSelectedLanguageDal
    {
        public List<AppSelectedLanguage> GetAll(Expression<Func<AppSelectedLanguage, bool>> filter = null)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.AppSelectedLanguage.Include(item => item.OtherLanguage).AsQueryable();

                if (filter != null) query = query.Where(filter);

                return query.ToList();

            }
        }

        public AppSelectedLanguage GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.AppSelectedLanguage.Where(item => item.Id == id).AsQueryable();
                return query.SingleOrDefault();
            }
        }
    }
}
