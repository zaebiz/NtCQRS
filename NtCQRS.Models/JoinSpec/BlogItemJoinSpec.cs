using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.EF;
using NtCQRS.Specification;

namespace NtCQRS.Models.JoinSpec
{
    public class BlogItemJoinSpec : IQueryJoin<Blog>
    {
        public IQueryable<Blog> Include(IQueryable<Blog> src)
        {
            return src
                .Include(b => b.Author)
                .Include(b => b.BlogPosts);
        }
    }
}
