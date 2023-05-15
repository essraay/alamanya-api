using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppSelectedLanguageManager : IAppSelectedLanguageService
    {

        IAppSelectedLanguageDal _appSelectedLanguageDal;

        public AppSelectedLanguageManager(IAppSelectedLanguageDal appSelectedLanguageDal)
        {
            _appSelectedLanguageDal = appSelectedLanguageDal;
        }

        public IResult Add(AppSelectedLanguage appSelectedLanguage)
        {
            _appSelectedLanguageDal.Add(appSelectedLanguage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(AppSelectedLanguage appSelectedLanguage)
        {
            _appSelectedLanguageDal.Delete(appSelectedLanguage);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<AppSelectedLanguage>> GetAll(Expression<Func<AppSelectedLanguage, bool>> filter = null)
        {
            return new SuccessDataResult<List<AppSelectedLanguage>>(_appSelectedLanguageDal.GetAll(filter), Messages.Listed);
        }

        public IDataResult<AppSelectedLanguage> GetById(int id)
        {
            return new SuccessDataResult<AppSelectedLanguage>(_appSelectedLanguageDal.GetById(id), Messages.Listed);
        }
    }
}
