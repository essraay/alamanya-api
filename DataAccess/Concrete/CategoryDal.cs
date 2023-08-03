using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CategoryDal : EfEntityRepositoryBase<Category, AlmanyaContext>, ICategoryDal
    {
        public Category GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.Category.Where(item => item.Id == id);
                return query.SingleOrDefault();
            }
        }
    }
}
