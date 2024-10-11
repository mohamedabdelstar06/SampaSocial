

namespace SempaSocial.BLL.ViewModel.PostVM
{
    public class CreatePostVM
    {
        public string? Body { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? UserName { get; set; }
    }
}