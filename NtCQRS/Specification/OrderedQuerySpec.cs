using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    /// <summary>
    /// набор параметров, кастомизирующих запрос к Ѕƒ, требующий возврата отсортированных данных
    /// </summary>
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

        /// <summary>
        /// стандартный набор параметров запроса
        /// </summary>
        public QuerySpec<TEntity> BaseSpec;

        /// <summary>
        /// объект описывающий требуемую сортировку
        /// </summary>
        public IQueryOrder<TEntity, TSortKey> Order { get; set; }
    }
}