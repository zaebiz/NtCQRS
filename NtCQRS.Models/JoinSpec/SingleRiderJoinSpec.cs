using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Models.JoinSpec
{
    public class SingleRiderJoinSpec : IQueryJoin<Riders>
    {
        public IQueryable<Riders> Include(IQueryable<Riders> src)
        {
            return src
                .Include(x => x.LookupRiderCategories)
                .Include(x => x.LookupRiderPositions);
            //.Include(x => x.RaceResults);
        }
    }
}
