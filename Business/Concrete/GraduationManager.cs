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
    public class GraduationManager : IGraduationService
    {
        IGraduationDal _graduationDal;
        public GraduationManager(IGraduationDal graduationDal)
        {
            _graduationDal = graduationDal;
        }
        public IDataResult<List<Graduation>> GetAll()
        {
            return new SuccessDataResult<List<Graduation>>(_graduationDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Graduation> GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
