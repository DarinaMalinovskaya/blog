using System;
using BlogMVC.Core;

namespace BlogMVC.Models
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {

        }

        public CommentViewModel(Comment comment, string userName)
        {
            Id = comment.Id;
            UserId = comment.UserId.ToString();
            BlogId = comment.BlogId;
            Text = comment.Text;
            UserName = userName;
            CreateDate = comment.CreateDate;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}