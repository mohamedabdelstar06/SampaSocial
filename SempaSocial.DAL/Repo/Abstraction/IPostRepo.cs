using SempaSocial.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.DAL.Repo.Abstraction
{
    public interface IPostRepo
    {
        List<Post> GetAllPosts(Expression<Func<Post, bool>>? filter);
        bool Create(Post post);
        bool Update(Post post);
        bool Delete(int id);
        Post GetById(int id);
        int? SaveChanges();

    }
}
