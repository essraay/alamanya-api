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
    public class OtherLanguageDal : EfEntityRepositoryBase<OtherLanguage, AlmanyaContext>, IOtherLanguageDal
    {
        public OtherLanguage GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.OtherLanguage.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
