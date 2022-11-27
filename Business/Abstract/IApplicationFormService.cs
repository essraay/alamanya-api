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
    public interface IApplicationFormService
    {
        IDataResult<List<ApplicationForm>> GetAll(Expression<Func<ApplicationForm, bool>> filter = null);
        IDataResult<ApplicationForm> GetById(int id);
        IResult Add(ApplicationForm applicationForm);
        IResult Delete(ApplicationForm applicationForm);
    }
}
