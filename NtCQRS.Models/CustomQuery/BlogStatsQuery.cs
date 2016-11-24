using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.EF;
using NtCQRS.Models.Models;
using NtCQRS.Query;

namespace NtCQRS.Models.CustomQuery
{
    /// <summary>
    /// пример реализации - потребовался нестандартный кастомный запрос,  возвращающий статистику по блогу
    /// для реализации были дополнительно добавлены: 
    /// модель данных статистики BlogStatistics
    /// в качестве спецификации используем список Id требуемых блогов (новый класс создавать не потребовалось)
    /// </summary>
    public class BlogStatsQuery
        : DbQueryBase
        , IDbQuery<List<BlogStatistics>, List<int>>
    {
        private BlogContext _concreteContext;

        public BlogStatsQuery(BlogContext ctx) : base(ctx)
        {
            _concreteContext = ctx;
            Spec = new List<int>();
        }

        /// <summary>
        /// список Id блогов, для которых треубется рассчитать статистику
        /// </summary>
        public List<int> Spec { get; set; }

        private IQueryable<BlogStatistics> Execute()
        {
            //_concreteContext.Posts
            //    .GroupBy(x => x.BlogId)
            //    .Select(g => new BlogStatistics()
            //    {
            //        BlogId = g.Key,
            //        FirstPost = g.Min(x => x.PostDate),
            //        LastPost = g.Max(x => x.PostDate),
            //        PostCount2014 = g.Count(x => x.PostDate.Year == 2014),
            //        PostCount2015 = g.Count(x => x.PostDate.Year == 2015),
            //        PostCount2016 = g.Count(x => x.PostDate.Year == 2016),
            //    }).ToList();

            var queryable = _concreteContext.Blogs.AsQueryable();
            if (Spec != null && Spec.Count > 0)
                queryable = queryable.Where(x => Spec.Any(s => s == x.Id));

            return queryable
                .Select(x => new BlogStatistics()
                {
                    BlogId = x.Id,
                    BlogName = x.Name,
                    FirstPost = x.BlogPosts.Min(p => p.PostDate),
                    LastPost = x.BlogPosts.Max(p => p.PostDate),
                    PostCount2014 = x.BlogPosts.Count(p => p.PostDate.Year == 2014),
                    PostCount2015 = x.BlogPosts.Count(p => p.PostDate.Year == 2015),
                    PostCount2016 = x.BlogPosts.Count(p => p.PostDate.Year == 2016),
                });
        }

        public List<BlogStatistics> GetResult()
            => Execute().ToList();

        public async Task<List<BlogStatistics>> GetResultAsync()
            => await Execute().ToListAsync();
    }
}
