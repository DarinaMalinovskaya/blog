using System;
using System.Collections.Generic;
using BlogMVC.Models;

namespace BlogMVC.Core
{
    public class Blog
    {
        public Blog()
        {
            Comments = new List<Comment>();
        }

        public Blog(BlogViewModel blogViewModel)
        {
            Id = blogViewModel.Id;
            UserId = blogViewModel.UserId;
            Title = blogViewModel.Title;
            Body = blogViewModel.Title;
            CreateDate = blogViewModel.CreateDate;
            Comments = blogViewModel.Comments;
        }

        public int Id { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public void MapFromViewModel(BlogViewModel blogViewModel)
        {
            Id = blogViewModel.Id;
            Title = blogViewModel.Title;
            Body = blogViewModel.Body;
        }
    }
}