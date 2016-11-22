using System;
using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public interface IQueryOrder<TEntity, TSortKey> 
        where TEntity : IDbEntity
    {
        int Direction { get; set; }
        Func<TEntity, TSortKey> Expression { get; set; }
    }
}
