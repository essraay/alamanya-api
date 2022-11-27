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
    public class GermanLanguageLevelDal : EfEntityRepositoryBase<GermanLanguageLevel, AlmanyaContext>, IGermanLanguageLevelDal
    {
        public GermanLanguageLevel GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.GermanLanguageLevel;
                return query.SingleOrDefault();
            }
        }
    }
}
