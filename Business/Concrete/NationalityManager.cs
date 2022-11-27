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
    public class NationalityManager : INationalityService
    {
        INationalityDal _nationalityDal;
        public NationalityManager(INationalityDal nationalityDal)
        {
            _nationalityDal = nationalityDal;
        }

        public IDataResult<List<Nationality>> GetAll()
        {
            return new SuccessDataResult<List<Nationality>>(_nationalityDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Nationality> GetById(int Id)
        {
            return new SuccessDataResult<Nationality>(_nationalityDal.GetById(Id), Messages.Listed);
        }
    }
}
