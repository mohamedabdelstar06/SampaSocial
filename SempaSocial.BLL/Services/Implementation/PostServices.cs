using AutoMapper;
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
    public class PostServices : IPostServices
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;

        public PostServices(IPostRepo postRepo,IMapper mapper)
        {
            _postRepo=postRepo;
            _mapper=mapper;
        }

        public bool Create(CreatePostVM postVM)
        {
            var Result = _mapper.Map<Post>(postVM);
            _postRepo.Create(Result);
            _postRepo.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _postRepo.Delete(id);
            _postRepo.SaveChanges();
            return true;
        }

        public List<GetPostVM> GetAll()
        {
            var posts = _postRepo.GetAllPosts(p=>p.IsDeleted != true);
            var Result = _mapper.Map<List<GetPostVM>>(posts);
            return Result;
        }

        public GetPostVM GetUser(int id)
        {

            var user = _postRepo.GetById(id);
            var res = _mapper.Map<GetPostVM>(user);
            return res;
        }

        public bool Update(GetPostVM postVM)
        {
            var user = _mapper.Map<Post>(postVM);
            _postRepo.Update(user);
            _postRepo.SaveChanges();
            return true;
        }
    }
}
