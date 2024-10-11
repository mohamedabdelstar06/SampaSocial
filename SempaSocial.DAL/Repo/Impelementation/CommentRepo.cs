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
    public class CommentRepo : ICommentRepo
    {
        private readonly SempaSocialDbContext _context;
        public CommentRepo(SempaSocialDbContext context) 
        {
            _context = context;
        }
        public bool Create(Comment comment)
        {
            _context.Add(comment);
            return true;
        }

        public bool Delete(int id)
        {
            _context.Remove(GetById(id));
            return true;
        }

        public List<Comment> GetAll()
        {
            var res= _context.Comments.ToList();
            return res;
        }

        public Comment GetById(int id)
        {
           var comm= _context.Comments.Find(id);
            return comm;
        }

        public int? SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool Update(Comment comment)
        {
            _context.Update(comment);
            return true;
        }
    }
}
