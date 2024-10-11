using AutoMapper;
using SempaSocial.BLL.Services.Abstraction;
using SempaSocial.BLL.ViewModel.CommentVM;
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
    public class CommentServices : ICommnetServices
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IMapper _mapper;
        public CommentServices(ICommentRepo commentRepo,IMapper mapper) 
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }
        public bool Create(CreateCommentVM commentVM)
        {
            var Result = _mapper.Map<Comment>(commentVM);
            _commentRepo.Create(Result);
            _commentRepo.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _commentRepo.Delete(id);
            _commentRepo.SaveChanges();
            return true;
        }

        public List<GetCommentVM> GetAll()
        {
            var comments = _commentRepo.GetAll();
            var Result = _mapper.Map<List<GetCommentVM>>(comments);
            return Result;
        }

        public GetCommentVM GetUser(int id)
        {
            var comment = _commentRepo.GetById(id);
            var res = _mapper.Map<GetCommentVM>(comment);
            return res;
        }

        public bool Update(GetCommentVM commentVM)
        {
            var comment = _mapper.Map<Comment>(commentVM);
            _commentRepo.Update(comment);
            _commentRepo.SaveChanges();
            return true;
        }
    }
}
