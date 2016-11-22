using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Query
{
    public class GetListQuery<TEntity>
        : DbQueryBase<TEntity>
            , IDbQuery<List<TEntity>, QuerySpecification<TEntity>> 
        where TEntity : class, IDbEntity
    {
        public GetListQuery(DbContext ctx) : base(ctx)
        {
            Spec = new QuerySpecification<TEntity>();
        }

        protected override IQueryable<TEntity> Execute()
            => _db.GetList(Spec);


        #region IQuery members

        public QuerySpecification<TEntity> Spec { get; set; }

        public List<TEntity> GetResult()
            => Execute().ToList();

        public async Task<List<TEntity>> GetResultAsync()
            => await Execute().ToListAsync();
        #endregion

    }
}