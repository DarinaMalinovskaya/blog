using System;
using System.Web.Mvc;
using System.Web.Routing;
using BlogMVC.Core;
using BlogMVC.EFData;
using BlogMVC.Models;

namespace BlogMVC.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public ActionResult CreateComment(CommentViewModel commentViewModel)
        {
            var comment = new Comment
            {
                BlogId = commentViewModel.BlogId,
                CreateDate = DateTime.Now,
                Text = commentViewModel.Text,
                UserId = new Guid(commentViewModel.UserId)
            };

            using (var context = new BlogContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }

            return RedirectToAction("BlogDetails", "Blog", new { blogId = commentViewModel.BlogId });
        }
    }
}