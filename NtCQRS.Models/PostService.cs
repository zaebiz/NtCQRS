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
    public class PostService
    {
        private readonly BlogContext _db;

        public PostService()
        {
            _db = new BlogContext();
        }

        /// <summary>
        /// пример - получение списка постов по фильтру
        /// </summary>
        public List<Post> GetBlogPosts(PostFilter postFilter)
        {
            var spec = new QuerySpec<Post>()
            {
                Join = new PostListJoinSpec(),
                Filter = postFilter
            };

            var sortOrder = QueryOrderFactory<Post>.Create(x => x.PostDate, 1);
            var query = new GetOrderedListQuery<Post, DateTime>(_db)
            {
                Spec = new OrderedQuerySpec<Post, DateTime>(spec, sortOrder)
            };

            return query.GetResult();
        }
    }
}
