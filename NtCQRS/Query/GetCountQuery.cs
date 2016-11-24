using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;
using NtCQRS.Specification;

namespace NtCQRS.Query
{
    public class GetCountQuery<TEntity>
        : DbQueryBase
        , IDbQuery<int, IQueryFilter<TEntity>>
        where TEntity : class, IDbEntity
    {
        public GetCountQuery(DbContext ctx) : base(ctx)
        {
        }

        public IQueryFilter<TEntity> Spec { get; set; }

        public int GetResult()
        {
            return _db
                .GetFilteredQueryable(Spec)
                .Count();
        }

        public async Task<int> GetResultAsync()
        {
            return await _db
                .GetFilteredQueryable(Spec)
                .CountAsync();
        }

        
    }
}
