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

        public IDataResult<OtherLanguage> GetById(int Id)
        {
            return new SuccessDataResult<OtherLanguage>(_otherLanguageDal.GetById(Id), Messages.Listed);
        }
    }
}
