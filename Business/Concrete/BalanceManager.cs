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
    public class BalanceManager : IBalanceService
    {

        IBalanceDal _balanceDal;

        public BalanceManager(IBalanceDal balanceDal)
        {
            _balanceDal = balanceDal;
        }

        public IDataResult<List<Balance>> GetAll()
        {
            return new SuccessDataResult<List<Balance>>(_balanceDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Balance> GetById(int Id)
        {
            return new SuccessDataResult<Balance>(_balanceDal.GetById(Id), Messages.Listed);
        }
    }
}
