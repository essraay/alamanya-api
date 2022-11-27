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
    public class ProvincesManager : IProvincesService
    {
        IProvincesDal _provincesDal;
        public ProvincesManager(IProvincesDal provincesDal)
        {
            _provincesDal = provincesDal;
        }

        public IDataResult<List<Provinces>> GetAll()
        {
            return new SuccessDataResult<List<Provinces>>(_provincesDal.GetAll(), Messages.Listed);

        }
        public IDataResult<Provinces> GetById(int Id)
        {
            return new SuccessDataResult<Provinces>(_provincesDal.GetById(Id), Messages.Listed);

        }
    }
}
