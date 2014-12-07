using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BlogMVC.Core;

namespace BlogMVC.Models
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
        }

        public BlogViewModel(Blog blog)
        {
            Id = blog.Id;
            Title = blog.Title;
            Body = blog.Body;
            CreateDate = blog.CreateDate;
            Comments = blog.Comments.ToList();
            UserId = blog.UserId;
        }

        public int Id { get; set; }

        [MaxLength(140)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }

        public DateTime CreateDate { get; set; }
        public List<Comment> Comments { get; set; }
        public Guid UserId { get; set; }

        public CommentViewModel CommentViewModel { get; set; }
    }
}