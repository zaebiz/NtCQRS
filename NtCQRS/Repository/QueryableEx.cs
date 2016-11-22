using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Repository
{
    public static class NtQueryableEx
    {
        public static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> src, IQueryFilter<TEntity> filter) where TEntity : IDbEntity
        {
            if (filter != null)
                src = filter.GetSatisfiedItems(src);

            return src;
        }

        public static IQueryable<TEntity> ApplyJoin<TEntity>(this IQueryable<TEntity> src, IQueryJoin<TEntity> join) where TEntity : IDbEntity
        {
            if (join != null)
                src = join.Include(src);

            return src;
        }

        public static IQueryable<TEntity> ApplyPaging<TEntity>(this IQueryable<TEntity> src, IQueryPaging paging) where TEntity : IDbEntity
        {
            if (paging != null)
                src = src.Skip(paging.Offset).Take(paging.PageSize);

            return src;
        }

        public static IQueryable<TEntity> ApplyOrder<TEntity, V>(this IQueryable<TEntity> src, IQueryOrder<TEntity, V> order) where TEntity : IDbEntity
        {
            if (order != null)
            {
                if (order.Direction == 0)
                    src = src.OrderBy(order.Expression).AsQueryable();
                else
                    src = src.OrderByDescending(order.Expression).AsQueryable();
            }

            return src;
        }

        
    }
}
