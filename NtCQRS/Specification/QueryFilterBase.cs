using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public class QueryFilterBase<TEntity> 
        : IQueryFilter<TEntity>
        where TEntity : IDbEntity
    {
        public int? Id { get; set; }
        public List<int> IdList { get; set; }


        public QueryFilterBase()
        {
            IdList = new List<int>();
        }

        public IQueryable<TEntity> GetSatisfiedItems(IQueryable<TEntity> src)
        {
            if (Id.GetValueOrDefault() > 0)
                src = src.Where(x => x.Id == this.Id);

            if (IdList != null && IdList.Count > 0)
                src = src.Where(x => this.IdList.Any(param => param == x.Id));

            return src;
        }
    }
}
