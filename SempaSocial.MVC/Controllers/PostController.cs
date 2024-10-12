using Microsoft.AspNetCore.Mvc;
using SempaSocial.DAL.Entities;

namespace SempaSocial.MVC.Controllers
{
    public class PostController : Controller
    {
        private static List<Post> posts = new List<Post>();

        // Display all posts
        public IActionResult Index()
        {
            return View(posts);
        }

        // Create a new post
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                posts.Add(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // Edit a post
        [HttpPost]
        public IActionResult Edit(long id, Post updatedPost)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post.Body = updatedPost.Body;
                post.Image = updatedPost.Image;
                post.IsDeleted = updatedPost.IsDeleted;
            }
            return RedirectToAction("Index");
        }

        // Delete a post
        public IActionResult Delete(long id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                posts.Remove(post);
            }
            return RedirectToAction("Index");
        }
    }
}
