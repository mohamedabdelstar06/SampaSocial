using SempaSocial.DAL.DB;
using SempaSocial.DAL.Entities;
using SempaSocial.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.DAL.Repo.Impelementation
{
    public class UserRepo : IUserRepo
    {
        private readonly SempaSocialDbContext _context;
        public UserRepo(SempaSocialDbContext context)
        {
            _context = context;
        }
        public bool Create(User user)
        {
            _context.Add(user);
            return true;
        }

        public bool Delete(int id)
        {
            _context.Remove(GetById(id));
            return true;
        }
        public List<User> GetAll()
        {
            var res = _context.Users.ToList();
            return res;
        }

        public User GetByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

        public User GetById(int id)
        {
            var users = _context.Users.Find(id);
            return users;
        }

        public int? SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool Update(User user)
        {
            _context.Update(user);
            return true;
        }
    }
}
