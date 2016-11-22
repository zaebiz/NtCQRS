using System;
using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public class QueryOrderBase<TEntity, TSortKey>
       : IQueryOrder<TEntity, TSortKey>
       where TEntity : IDbEntity
    {
        public int Direction { get; set; }
        public Func<TEntity, TSortKey> Expression { get; set; }
    }
}
