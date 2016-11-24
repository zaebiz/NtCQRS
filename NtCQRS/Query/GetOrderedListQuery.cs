using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NtCQRS.Repository;
using NtCQRS.Specification;

namespace NtCQRS.Query
{
    /// <summary>
    /// класс для запросов сущностей из БД списком
    /// Spec - паремтры запроса (фильтрация, пагинация, сортировка)
    /// можно не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип
    /// </summary>
    public class GetOrderedListQuery<TEntity, TSortKey>
        : GetListQuery<TEntity>
        , IDbQuery<List<TEntity>, OrderedQuerySpec<TEntity, TSortKey>>
        where TEntity : class, IDbEntity
    {
        public GetOrderedListQuery(DbContext db) : base(db)
        {
            // todo инициализировать Spec с помощью фабрики
            //Spec = new 
        }

        public new OrderedQuerySpec<TEntity, TSortKey> Spec { get; set; }

        protected override IQueryable<TEntity> Execute()
        {
            var queryable = _db.GetOrderedList(Spec);
            if (AttachResultToContext)
                queryable = queryable.AsNoTracking();

            return queryable;
        }
    }
}