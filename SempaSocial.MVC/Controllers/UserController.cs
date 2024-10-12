using Microsoft.AspNetCore.Mvc;
using SempaSocial.DAL.Entities;

namespace SempaSocial.MVC.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();

        // Display all users
        public IActionResult Index()
        {
            return View(users);
        }

        // Add a new user
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                users.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Edit user details
        [HttpPost]
        public IActionResult Edit(string id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.FullName = updatedUser.FullName;
                user.Image = updatedUser.Image;
                user.IsDeleted = updatedUser.IsDeleted;
            }
            return RedirectToAction("Index");
        }

        // Delete a user
        public IActionResult Delete(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
            return RedirectToAction("Index");
        }
    }
}
