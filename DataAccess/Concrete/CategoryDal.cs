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
                var query = context.Category.Where(item => item.Id == id)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.Provinces)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.District)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.Nationality)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.Gender)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.AgeRange)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.Graduation)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.GermanLevel)
                    .Include(category => category.ApplicationForms).ThenInclude(form => form.Balance);
                return query.SingleOrDefault();
            }
        }
    }
}
