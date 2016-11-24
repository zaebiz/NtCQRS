using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NtCQRS.Models.EF
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
            Database.SetInitializer(new BlogInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}
