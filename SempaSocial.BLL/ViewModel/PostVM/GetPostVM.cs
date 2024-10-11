using SempaSocial.DAL.Entities;
using System;
using System.Collections.Generic;


namespace SempaSocial.BLL.ViewModel.PostVM
{
    public class GetPostVM
    {
        public long Id { get; set; }
        public string? Body { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? UserName { get; set; }
    }
}
