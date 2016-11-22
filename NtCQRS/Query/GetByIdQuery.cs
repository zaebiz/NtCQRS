using System.Data.Entity;
using System.Threading.Tasks;
using NtCQRS.Repository;
using NtCQRS.Specification;

namespace NtCQRS.Query
{
    public class GetByIdQuery<TEntity>
        : DbQueryBase<TEntity>
        , IDbQuery<TEntity, GetByIdSpec<TEntity>>
        where TEntity : class, IDbEntity
    {
        public GetByIdQuery(DbContext ctx) : base(ctx)
        {}

        public GetByIdSpec<TEntity> Spec { get; set; }

        public TEntity GetResult()
            => _db.GetItemById<TEntity>(Spec);

        public async Task<TEntity> GetResultAsync()
            => await Task.FromResult(GetResult());
    }
}