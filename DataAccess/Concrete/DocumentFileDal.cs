using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DocumentFileDal : EfEntityRepositoryBase<DocumentFile, AlmanyaContext>, IDocumentFileDal
    {
        public DocumentFile GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.DocumentFile.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
