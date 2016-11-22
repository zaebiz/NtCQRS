using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NtCQRS.Specification;

namespace NtCQRS.Query
{
    public class GetOrderedListQuery<TEntity, TSortKey>
        : GetListQuery<TEntity>
            , IDbQuery<List<TEntity>, OrderedQuerySpecification<TEntity, TSortKey>>
        where TEntity : class, IDbEntity
    {
        public GetOrderedListQuery(DbContext db) : base(db)
        {
            // todo инициализировать Spec с помощью фабрики
            //Spec = new 
        }

        public new OrderedQuerySpecification<TEntity, TSortKey> Spec { get; set; }

        protected override IQueryable<TEntity> Execute()
            => _db.GetOrderedList(Spec);
    }
}