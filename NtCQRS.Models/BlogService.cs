using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.CustomQuery;
using NtCQRS.Models.EF;
using NtCQRS.Models.JoinSpec;
using NtCQRS.Models.Models;
using NtCQRS.Models.SearchFilters;
using NtCQRS.Query;
using NtCQRS.Specification;

namespace NtCQRS.Models
{
    public class BlogService
    {
        private readonly BlogContext _db;

        public BlogService()
        {
            _db = new BlogContext();
        }

        /// <summary>
        /// пример - получение блога по ID
        /// </summary>
        public Blog GetBlogById(int blogId)
        {
            var query = new GetByIdQuery<Blog>(_db)
            {
                Spec = new GetByIdSpec<Blog>()
                {
                    Id = blogId,
                    Join = new BlogItemJoinSpec()
                }
            };

            return query.GetResult();
        }

        /// <summary>
        /// пример - получение кол-ва блогов учитывая фильтр
        /// </summary>
        public int GetBlogCount(BlogFilter filter)
        {
            var query = new GetCountQuery<Blog>(_db)
            {
                Spec = filter
            };

            return query.GetResult();
        }

        /// <summary>
        /// пример - получение списка блогов по фильтру
        /// </summary>
        public List<Blog> GetBlogList(BlogFilter filter)
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

            return query.GetResult();
        }

        /// <summary>
        /// пример - выполнение кастомного асинхронного запроса  и получение результатов
        /// </summary>
        public async Task<List<BlogStatistics>> GetBlogStats(List<int> statFilter)
        {
            var query = new BlogStatsQuery(_db)
            {
                Spec = statFilter
            };

            return await query.GetResultAsync();
        }

    }
}
