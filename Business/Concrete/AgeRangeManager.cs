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
    public class AgeRangeManager : IAgeRangeService
    {
        IAgeRangeDal _ageRangeDal;

        public AgeRangeManager(IAgeRangeDal ageRangeDal)
        {
            _ageRangeDal = ageRangeDal;
        }

        public IDataResult<List<AgeRange>> GetAll()
        {
            return new SuccessDataResult<List<AgeRange>>(_ageRangeDal.GetAll(), Messages.Listed);
        }

        public IDataResult<AgeRange> GetById(int Id)
        {
            return new SuccessDataResult<AgeRange>(_ageRangeDal.GetById(Id), Messages.Listed);
        }

    }
}
