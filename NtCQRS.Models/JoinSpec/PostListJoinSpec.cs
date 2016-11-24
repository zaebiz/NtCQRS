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
    /// <summary>
    /// спецификация - какие таблицы включать в результат 
    /// при получении списка постов из БД
    /// </summary>
    public class PostListJoinSpec : IQueryJoin<Post>
    {
        public IQueryable<Post> Include(IQueryable<Post> src)
        {
            return src
                .Include(x => x.Blog)
                .Include(x => x.Blog.Author);
        }
    }
}
