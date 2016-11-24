using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.EF;
using NtCQRS.Specification;

namespace NtCQRS.Models.SearchFilters
{
    public class BlogFilter : QueryFilterBase<Blog>
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? PostCountGreaterThen { get; set; }
        public DateTime HasPostLaterThen { get; set; } = DateTime.MinValue;

        public override IQueryable<Blog> GetSatisfiedItems(IQueryable<Blog> src)
        {
            if (UserId.GetValueOrDefault() > 0)
                src = src.Where(b => b.Author.Id == UserId);

            if (!string.IsNullOrEmpty(UserName))
                src = src.Where(b => b.Author.Name.Contains(UserName));

            if (PostCountGreaterThen.HasValue)
                src = src.Where(b => b.BlogPosts.Count >= PostCountGreaterThen.Value);

            if (HasPostLaterThen > DateTime.MinValue)
                src = src.Where(b => 
                    b.BlogPosts.Any(x => 
                        x.PostDate >= HasPostLaterThen));


            return base.GetSatisfiedItems(src);
        }
    }
}
