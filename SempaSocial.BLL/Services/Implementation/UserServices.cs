using AutoMapper;
using Microsoft.Extensions.Hosting;
using SempaSocial.BLL.Services.Abstraction;
using SempaSocial.BLL.ViewModel.PostVM;
using SempaSocial.BLL.ViewModel.UserVM;
using SempaSocial.DAL.Entities;
using SempaSocial.DAL.Repo.Abstraction;
using SempaSocial.DAL.Repo.Impelementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.BLL.Services.Implementation
{
    public class UserServices: IUserServices
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public UserServices(IUserRepo userRepo, IMapper mapper) 
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public bool Create(CreateUserVM userVM)
        {
            var Result = _mapper.Map<User>(userVM);
            _userRepo.Create(Result);
            _userRepo.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _userRepo.Delete(id);
            _userRepo.SaveChanges();
            return true;
        }

        public List<GetUserVM> GetAll()
        {
            var users = _userRepo.GetAll();
            var Result = _mapper.Map<List<GetUserVM>>(users);
            return Result;
        }

        public GetUserVM GetUser(int id)
        {
            var user = _userRepo.GetById(id);
            var res = _mapper.Map<GetUserVM>(user);
            return res;
        }

        public LoginVM Login(string email, string password)
        {
            var res = _userRepo.GetByEmail(email);
            if (res.PasswordHash==password)
            {
                return _mapper.Map<LoginVM>(res);
            }
            return null;
        }

        public CreateUserVM Register(CreateUserVM userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _userRepo.Create(user);
            _userRepo.SaveChanges();
            return userVM;
        }

        public bool Update(GetUserVM userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _userRepo.Update(user);
            _userRepo.SaveChanges();
            return true;
        }
    }
}
