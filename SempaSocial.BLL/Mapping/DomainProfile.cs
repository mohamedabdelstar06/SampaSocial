using AutoMapper;
using SempaSocial.BLL.ViewModel.CommentVM;
using SempaSocial.BLL.ViewModel.PostVM;
using SempaSocial.BLL.ViewModel.UserVM;
using SempaSocial.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SempaSocial.BLL.Mapping
{

    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            CreateMap<CreateUserVM, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest=>dest.FullName,opt=>opt.MapFrom(src=>src.Name))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ConfirmPassword, opt => opt.DoNotValidate());
          
            CreateMap<GetUserVM,User>();
          
            CreateMap<LoginVM,User >()
                .ForMember(dest=>dest.PasswordHash, opt=>opt.MapFrom(src=>src.Password));
            CreateMap<GetPostVM, Post>();
            CreateMap<GetUserVM, User>();
            CreateMap<GetCommentVM, Comment>();
            CreateMap<CreateCommentVM, Comment>();

        }
    }
}
