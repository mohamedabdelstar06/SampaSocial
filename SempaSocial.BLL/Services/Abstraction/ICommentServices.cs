



using SempaSocial.BLL.ViewModel.CommentVM;

namespace SempaSocial.BLL.Services.Abstraction
{
    public interface ICommnetServices
    {
        List<GetCommentVM> GetAll();
        bool Create(CreateCommentVM commentVM);
        bool Delete(int id);
        bool Update(GetCommentVM commentVM);
        GetCommentVM GetUser(int id);
    }
}