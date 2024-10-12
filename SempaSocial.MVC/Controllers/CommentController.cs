using Microsoft.AspNetCore.Mvc;
using SempaSocial.DAL.Entities;

namespace SempaSocial.MVC.Controllers
{
    public class CommentController : Controller
    {
        private static List<Comment> comments = new List<Comment>();

        // Display comments for a specific post
        public IActionResult Index(long postId)
        {
            var postComments = comments.Where(c => c.PostId == postId).ToList();
            return View(postComments);
        }

        // Add a comment
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comments.Add(comment);
                return RedirectToAction("Index", new { postId = comment.PostId });
            }
            return View(comment);
        }

        // Edit a comment
        [HttpPost]
        public IActionResult Edit(long id, Comment updatedComment)
        {
            var comment = comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                comment.Body = updatedComment.Body;
                comment.Image = updatedComment.Image;
                comment.IsDeleted = updatedComment.IsDeleted;
            }
            return RedirectToAction("Index", new { postId = updatedComment.PostId });
        }

        // Delete a comment
        public IActionResult Delete(long id)
        {
            var comment = comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                comments.Remove(comment);
            }
            return RedirectToAction("Index", new { postId = comment.PostId });
        }
    }
}
