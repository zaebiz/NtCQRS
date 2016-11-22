using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    // todo - можно переделать в класс
    public class QuerySpec<TEntity> where TEntity : IDbEntity
    {
        public QuerySpec()
        {
            Paging = new QueryPaging(20, 0);
            DefaultOrder = QueryOrderFactory<TEntity>.Create();
        }

        public IQueryFilter<TEntity> Filter { get; set; }
        public IQueryJoin<TEntity> Join { get; set; }
        public IQueryPaging Paging { get; set; }
        // пейджинг без сортировки не работает
        public IQueryOrder<TEntity, int> DefaultOrder { get; }
    }
}
