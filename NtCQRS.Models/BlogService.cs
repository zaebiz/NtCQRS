using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.EF;
using NtCQRS.Models.JoinSpec;
using NtCQRS.Models.SearchFilters;
using NtCQRS.Query;
using NtCQRS.Specification;

namespace NtCQRS.Models
{
    public class BlogService
    {
        private BlogContext _db;

        public BlogService()
        {
            _db = new BlogContext();
        }

        public void GetBlogList(BlogFilter filter)
        {
            var query = new GetListQuery<Blog>(_db)
            {
                Spec = new QuerySpec<Blog>()
                {
                    Join = new BlogListJoinSpec(),
                    Paging = new QueryPaging(50, 0),
                    Filter = filter,
                }
            };

            var blog = query.GetResult();
            return;
        }

        public async Task GetOrderedBlogList(BlogFilter filter)
        {
            var sortOrder = QueryOrderFactory<Blog>.Create<DateTime>(x => x.CreateDate);
            var baseSpec = new QuerySpec<Blog>()
            {
                Join = new BlogListJoinSpec(),
                Filter = filter,
            };

            var query = new GetOrderedListQuery<Blog, DateTime>(_db)
            {
                Spec = new OrderedQuerySpec<Blog, DateTime>(baseSpec, sortOrder)
            };

            var blog = await query.GetResultAsync();
            return;
        }
    }
}
