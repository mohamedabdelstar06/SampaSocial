using SempaSocial.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.DAL.Repo.Abstraction
{
    public interface ICommentRepo
    {
        List<Comment> GetAll();
        bool Create(Comment comment);
        bool Update(Comment comment);
        bool Delete(int id);
        Comment GetById(int id);
        int? SaveChanges();
    }
}
