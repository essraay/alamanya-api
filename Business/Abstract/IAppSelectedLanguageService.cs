using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppSelectedLanguageService
    {
        IDataResult<List<AppSelectedLanguage>> GetAll(Expression<Func<AppSelectedLanguage, bool>> filter = null);
        IDataResult<AppSelectedLanguage> GetById(int id);
        IResult Add(AppSelectedLanguage appSelectedLanguage);
        IResult Delete(AppSelectedLanguage appSelectedLanguage);
    }
}
