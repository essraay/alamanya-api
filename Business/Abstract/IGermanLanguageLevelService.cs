using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGermanLanguageLevelService
    {
        IDataResult<List<GermanLanguageLevel>> GetAll();

        IDataResult<GermanLanguageLevel> GetById(int Id);
    }
}
