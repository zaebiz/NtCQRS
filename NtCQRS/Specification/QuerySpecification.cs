using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    /// <summary>
    /// Набор параметров, кастомизирующих запрос к БД
    /// </summary>
    public class QuerySpec<TEntity> where TEntity : IDbEntity
    {
        public QuerySpec()
        {
            Paging = new QueryPaging(20, 0);
            DefaultOrder = QueryOrderFactory<TEntity>.Create();
        }

        /// <summary>
        /// объект, содержащий параметры для фильтрации сущностей
        /// </summary>
        public IQueryFilter<TEntity> Filter { get; set; }

        /// <summary>
        /// объект, содержащий информацию о включении в результаты запроса доп. таблиц
        /// </summary>
        public IQueryJoin<TEntity> Join { get; set; }

        /// <summary>
        /// пагинация
        /// </summary>
        public IQueryPaging Paging { get; set; }


        // пейджинг без сортировки не работает
        public IQueryOrder<TEntity, int> DefaultOrder { get; }
    }
}
