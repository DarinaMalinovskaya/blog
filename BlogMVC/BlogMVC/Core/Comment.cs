using System;

namespace BlogMVC.Core
{
    public class Comment
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
    }
}