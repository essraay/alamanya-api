using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ApplicationFormDal : EfEntityRepositoryBase<ApplicationForm, AlmanyaContext>, IApplicationFormDal
    {
        public Task<bool> AddDto(ApplicationFormDto applicationFormDto)
        {
            throw null;
        }

        public List<ApplicationForm> GetAll(Expression<Func<ApplicationForm, bool>> filter = null)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.ApplicationForm
                    .Include(item => item.Balance)
                    .Include(item => item.Category)
                    .Include(item => item.Provinces)
                    .Include(item => item.District)
                    .Include(item => item.Nationality)
                    .Include(item => item.Gender)
                    .Include(item => item.AgeRange)
                    .Include(item => item.Graduation)
                    .Include(item => item.AppSelectedLanguages).ThenInclude(x => x.OtherLanguage)
                    .Include(item => item.GermanLevel).AsQueryable();

                if (filter != null) query = query.Where(filter);

                return query.ToList();
            }
        }

        public ApplicationForm GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.ApplicationForm.Where(item => item.Id == id)
                    .Include(item => item.Balance)
                    .Include(item => item.Category)
                    .Include(item => item.Provinces)
                    .Include(item => item.District)
                    .Include(item => item.Nationality)
                    .Include(item => item.Gender)
                    .Include(item => item.AgeRange)
                    .Include(item => item.Graduation)
                    .Include(item => item.GermanLevel)
                    .Include(item => item.AppSelectedLanguages).ThenInclude(x => x.OtherLanguage)
                    .AsQueryable();
                return query.SingleOrDefault();
            }
        }
    }
}
