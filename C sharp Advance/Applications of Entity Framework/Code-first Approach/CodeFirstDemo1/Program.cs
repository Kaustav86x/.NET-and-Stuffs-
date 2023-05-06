using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo1
{
    public class Post
    {
        public string Id { get; set; }
        public DateTime DataPublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
