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
    public class ApplicationFormManager : IApplicationFormService
    {
        IApplicationFormDal _applicationFormDal;

        public ApplicationFormManager(IApplicationFormDal applicationFormDal)
        {
            _applicationFormDal = applicationFormDal;
        }

        public IResult Add(ApplicationForm applicationForm)
        {
            _applicationFormDal.Add(applicationForm);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ApplicationForm applicationForm)
        {
            _applicationFormDal.Delete(applicationForm);
            return new SuccessResult(Messages.Delete);
        }

        public IDataResult<List<ApplicationForm>> GetAll(Expression<Func<ApplicationForm, bool>> filter = null)
        {
            return new SuccessDataResult<List<ApplicationForm>>(_applicationFormDal.GetAll(filter), Messages.Listed);
        }

        public IDataResult<ApplicationForm> GetById(int id)
        {
            return new SuccessDataResult<ApplicationForm>(_applicationFormDal.GetById(id), Messages.Listed);
        }
    }
}
