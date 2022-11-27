using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDocumentFileService
    {
        IDataResult<List<DocumentFile>> GetAll();
        IResult Add(DocumentFile documentFile);
        IResult Delete(DocumentFile documentFile);
        IResult Update(DocumentFile documentFile);
        IDataResult<DocumentFile> GetById(int Id);
    }
}
