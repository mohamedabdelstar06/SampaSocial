using Microsoft.AspNetCore.Identity;
namespace SempaSocial.DAL.Entities
{
    public class User :IdentityUser
    {
        public string? FullName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
