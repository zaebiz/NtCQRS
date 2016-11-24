using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public class OrderedQuerySpec<TEntity, TSortKey> where TEntity : IDbEntity
    {
        public OrderedQuerySpec()
        {
            BaseSpec = new QuerySpec<TEntity>();
        }

        public OrderedQuerySpec(QuerySpec<TEntity> baseSpec)
        {
            BaseSpec = baseSpec;
        }

        public OrderedQuerySpec(QuerySpec<TEntity> baseSpec, IQueryOrder<TEntity, TSortKey> order)
        {
            BaseSpec = baseSpec;
            Order = order;
        }

        public QuerySpec<TEntity> BaseSpec;
        public IQueryOrder<TEntity, TSortKey> Order { get; set; }
    }
}