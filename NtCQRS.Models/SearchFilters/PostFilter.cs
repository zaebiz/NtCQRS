using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.EF;
using NtCQRS.Specification;

namespace NtCQRS.Models.SearchFilters
{
    public class PostFilter : QueryFilterBase<Post>
    {
        public int? BlogId { get; set; }
        public DateTime PostDateLaterThen { get; set; } = DateTime.MinValue;

        public override IQueryable<Post> GetSatisfiedItems(IQueryable<Post> src)
        {
            if (BlogId.GetValueOrDefault() > 0)
                src = src.Where(x => x.BlogId == BlogId);

            if (PostDateLaterThen > DateTime.MinValue)
                src = src.Where(x => x.PostDate > PostDateLaterThen);

            return base.GetSatisfiedItems(src);
        }
    }
}
