using System.Data.Entity;
using System.Linq;
using NtCQRS.Models.EF;
using NtCQRS.Specification;

namespace NtCQRS.Models.JoinSpec
{
    public class BlogListJoinSpec : IQueryJoin<Blog>
    {
        public IQueryable<Blog> Include(IQueryable<Blog> src)
        {
            return src
                .Include(b => b.Author);
        }
    }
}