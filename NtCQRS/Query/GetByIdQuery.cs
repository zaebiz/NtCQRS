using System.Data.Entity;
using System.Threading.Tasks;

namespace NtCQRS.Query
{
    public class GetByIdQuery<TEntity>
        : DbQueryBase<TEntity>
        , IDbQuery<TEntity, int>
        where TEntity : class, IDbEntity
    {
        public GetByIdQuery(DbContext ctx) : base(ctx)
        {}

        public int Spec { get; set; }

        public TEntity GetResult()
            => _db.GetItemById<TEntity>(Spec);

        public async Task<TEntity> GetResultAsync()
            => await Task.FromResult(GetResult());
    }
}