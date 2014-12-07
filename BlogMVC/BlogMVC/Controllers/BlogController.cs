using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlogMVC.Core;
using BlogMVC.EFData;
using BlogMVC.Models;
using Microsoft.AspNet.Identity;

namespace BlogMVC.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<BlogViewModel> blogs;
            using (var context = new BlogContext())
            {
                blogs = context.Blogs.ToList().Select(mod => new BlogViewModel(mod)).ToList();
            }

            return View(blogs);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(BlogViewModel blogModel)
        {
            var userId = new Guid(HttpContext.User.Identity.GetUserId());
            var blog = new Blog
            {
                Title = blogModel.Title,
                Body = blogModel.Body,
                CreateDate = DateTime.Now,
                UserId = userId
            };

            using (var context = new BlogContext())
            {
                context.Blogs.Add(blog);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        public ActionResult EditBlog(int blogId)
        {
            BlogViewModel blogViewModel;
            using (var context = new BlogContext())
            {
                var blog = context.Blogs.Find(blogId);
                blogViewModel = new BlogViewModel(blog);
            }

            return View(blogViewModel);
        }

        [HttpPost]
        public ActionResult EditBlog(BlogViewModel blogModel)
        {
            using (var context = new BlogContext())
            {
                var blog = context.Blogs.Find(blogModel.Id);
                blog.MapFromViewModel(blogModel);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        public ActionResult BlogDetails(int? blogId)
        {
            BlogViewModel blogViewModel;
            using (
                var context = new BlogContext())
            {
                var blog = context.Blogs.Find(blogId);
                blogViewModel = new BlogViewModel(blog);
            }

            blogViewModel.CommentViewModel = new CommentViewModel
            {
                BlogId = blogId.GetValueOrDefault()
            };

            return View(blogViewModel);
        }
    }
}