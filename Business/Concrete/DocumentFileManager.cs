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
    public class DocumentFileManager : IDocumentFileService
    {
        IDocumentFileDal _documentFileDal;

        public DocumentFileManager(IDocumentFileDal documentFileDal)
        {
            _documentFileDal = documentFileDal;
        }
        public IResult Add(DocumentFile documentFile)
        {
            _documentFileDal.Add(documentFile);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(DocumentFile documentFile)
        {
            _documentFileDal.Delete(documentFile);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<DocumentFile>> GetAll()
        {
            return new SuccessDataResult<List<DocumentFile>>(_documentFileDal.GetAll(), Messages.Listed);
        }

        public IDataResult<DocumentFile> GetById(int Id)
        {
            return new SuccessDataResult<DocumentFile>(_documentFileDal.GetById(Id), Messages.Listed);

        }

        public IResult Update(DocumentFile documentFile)
        {
            _documentFileDal.Update(documentFile);
            return new SuccessResult(Messages.Updated);
        }
    }
}
