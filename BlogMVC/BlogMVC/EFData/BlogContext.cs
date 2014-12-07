using System.Data.Entity;
using BlogMVC.Core;
using BlogMVC.EFData.Mapping;

namespace BlogMVC.EFData
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogConnectionString")
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>()
            //    .HasMany(mod => mod.Comments)
            //    .WithRequired(mod => mod.Blog)
            //    .HasForeignKey(mod => mod.BlogId);
            //modelBuilder.Configurations.Add(new BlogMap());
            //modelBuilder.Configurations.Add(new CommentMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}