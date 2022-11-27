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
    public class GermanLanguageLevelManager : IGermanLanguageLevelService
    {
        IGermanLanguageLevelDal _germanLanguageLevelDal;

        public GermanLanguageLevelManager(IGermanLanguageLevelDal germanLanguageLevelDal)
        {
            _germanLanguageLevelDal = germanLanguageLevelDal;
        }

        public IDataResult<List<GermanLanguageLevel>> GetAll()
        {
            return new SuccessDataResult<List<GermanLanguageLevel>>(_germanLanguageLevelDal.GetAll(), Messages.Listed);
        }

        public IDataResult<GermanLanguageLevel> GetById(int Id)
        {
            return new SuccessDataResult<GermanLanguageLevel>(_germanLanguageLevelDal.GetById(Id), Messages.Listed);
        }
    }
}
