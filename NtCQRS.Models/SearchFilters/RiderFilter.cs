using System.Linq;
using NtCQRS.Specification;

namespace NtCQRS.Models.SearchFilters
{
    public class RiderFilter : QueryFilterBase<Riders>
    {
        public string RiderName { get; set; }

        public override IQueryable<Riders> GetSatisfiedItems(IQueryable<Riders> src)
        {
            if (!string.IsNullOrEmpty(RiderName))
                src = src.Where(x => x.Name.Contains(this.RiderName));

            return base.GetSatisfiedItems(src);
        }
    }
}
