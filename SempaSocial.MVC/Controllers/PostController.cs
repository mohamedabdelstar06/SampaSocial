using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SempaSocial.BLL.Services.Abstraction;

namespace SempaSocial.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostServices postServices;

        public PostController(IPostServices postServices)
        {
            this.postServices=postServices;
        }
        public IActionResult Index()
        {

            //BackgroundJob.Enqueue(() => postServices.GetAll());

           
            Welcome();
            return View();
        }

        public void Welcome()
        {
            Console.WriteLine("Welcome");
        }
    }
}
