using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public class OrderedQuerySpec<TEntity, TSortKey> where TEntity : IDbEntity
    {
        public OrderedQuerySpec()
        {
            Spec = new QuerySpec<TEntity>();
        }

        public QuerySpec<TEntity> Spec;
        public IQueryOrder<TEntity, TSortKey> Order { get; set; }
    }
}