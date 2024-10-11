using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.BLL.ViewModel.CommentVM
{
    public class CreateCommentVM
    {
        public string? Body { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        [ForeignKey("Post")]
        public long? PostId { get; set; }
    }
}
