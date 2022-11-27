using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAgeRangeService
    {
        IDataResult<List<AgeRange>> GetAll();
        IDataResult<AgeRange> GetById(int Id);
    }
}
