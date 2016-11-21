namespace NtCQRS.Specification
{
    public class OrderedQuerySpecification<TEntity, TSortKey> where TEntity : IDbEntity
    {
        public OrderedQuerySpecification()
        {
            Spec = new QuerySpecification<TEntity>();
        }

        public QuerySpecification<TEntity> Spec;
        public IQueryOrder<TEntity, TSortKey> Order { get; set; }
    }
}