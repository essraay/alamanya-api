using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OtherLanguageManager : IOtherLanguageService
    {
        IOtherLanguageDal _otherLanguageDal;

        public OtherLanguageManager(IOtherLanguageDal otherLanguageDal)
        {
            _otherLanguageDal = otherLanguageDal;
        }

        public IResult Add(OtherLanguage otherLanguage)
        {
            _otherLanguageDal.Add(otherLanguage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(OtherLanguage otherLanguage)
        {
            _otherLanguageDal.Delete(otherLanguage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<OtherLanguage>> GetAll()
        {
            return new SuccessDataResult<List<OtherLanguage>>(_otherLanguageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<OtherLanguage> GetById(int Id)
        {
            return new SuccessDataResult<OtherLanguage>(_otherLanguageDal.GetById(Id), Messages.Listed);
        }
    }
}
