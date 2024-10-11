using SempaSocial.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.DAL.Repo.Abstraction
{
    public interface IUserRepo
    {
        List<User> GetAll();
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
        User GetById(int id);
        User GetByEmail(string email);
        int? SaveChanges();
    }
}
