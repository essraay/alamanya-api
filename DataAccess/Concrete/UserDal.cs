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
    public class UserDal : EfEntityRepositoryBase<User, AlmanyaContext>, IUserDal
    {

        public User GetById(int id)
        {
            using (AlmanyaContext context = new AlmanyaContext())
            {
                var query = context.User;
                return query.SingleOrDefault();
            }
        }

    }
}

