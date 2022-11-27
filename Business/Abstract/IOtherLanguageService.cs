using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOtherLanguageService
    {
        IDataResult<List<OtherLanguage>> GetAll();
        IResult Add(OtherLanguage otherLanguage);
        IResult Delete(OtherLanguage otherLanguage);
        IDataResult<OtherLanguage> GetById(int Id);
    }
}
