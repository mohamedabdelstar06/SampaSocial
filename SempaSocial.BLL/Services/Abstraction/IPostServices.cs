using SempaSocial.BLL.ViewModel.PostVM;
using SempaSocial.BLL.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.BLL.Services.Abstraction
{
    public interface IPostServices
    {
        List<GetPostVM> GetAll();
        bool Create(CreatePostVM postVM);
        bool Delete(int id);
        bool Update(GetPostVM postVM);
        GetPostVM GetUser(int id);
    }
}
