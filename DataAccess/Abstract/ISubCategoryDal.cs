using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISubCategoryDal : IEntityRepository<SubCategory>
    {
        List<SubCategory> GetAll(Expression<Func<SubCategory, bool>> filter = null);
        SubCategory GetById(int id);
    }
}
