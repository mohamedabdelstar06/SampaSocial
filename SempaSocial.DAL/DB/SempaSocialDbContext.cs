using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SempaSocial.DAL.Entities;


namespace SempaSocial.DAL.DB
{
    public class SempaSocialDbContext:IdentityDbContext
    {
        //Enhance Connection String 
        public SempaSocialDbContext(DbContextOptions<SempaSocialDbContext> opt):base(opt)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
