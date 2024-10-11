using SempaSocial.BLL.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.BLL.Services.Abstraction
{
    public interface IUserServices
    {
        List<GetUserVM> GetAll();
        bool Create(CreateUserVM userVM);
        bool Delete (int  id);
        bool Update(GetUserVM userVM);
        GetUserVM GetUser(int id);
        LoginVM Login(string email, string password);
        CreateUserVM Register(CreateUserVM userVM);
    }
}
