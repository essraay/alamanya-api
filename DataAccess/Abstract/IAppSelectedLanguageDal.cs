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
    public interface IAppSelectedLanguageDal :IEntityRepository<AppSelectedLanguage>
    {
        List<AppSelectedLanguage> GetAll(Expression<Func<AppSelectedLanguage, bool>> filter = null);
        AppSelectedLanguage GetById(int id);
    }
}
