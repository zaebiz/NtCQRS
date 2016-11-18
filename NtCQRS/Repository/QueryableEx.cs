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
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> src, INtFilter<T> filter) where T : class
        {
            if (filter != null)
                src = filter.GetSatisfiedItems(src);

            return src;
        }

        public static IQueryable<T> ApplyJoin<T>(this IQueryable<T> src, INtJoin<T> join) where T : class
        {
            if (join != null)
                src = join.Include(src);

            return src;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> src, INtPaging paging) where T : class
        {
            if (paging != null)
                src = src.Skip(paging.Offset).Take(paging.PageSize);

            return src;
        }

        public static IQueryable<T> ApplyOrder<T, V>(this IQueryable<T> src, INtOrder<T, V> order) where T : class
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



        //public static IQueryable<T> GetFilteredList<T>(this IQueryable<T> src, INtSpecification<T> filter) where T : class
        //{
        //    return src.ApplyFilter(filter);
        //}

        //public static IQueryable<T> GetPagedFilteredList<T>(this IQueryable<T> src, INtSpecification<T> filter, INtPaging paging) where T : class
        //{
        //    return src
        //        .ApplyFilter(filter)
        //        .ApplyPaging(paging);
        //}



        //public static IQueryable<T> GetFilteredList<T>(this IQueryable<T> src, ISpecification<T> filter) where T : class
        //    => src.ApplyFilter(filter);
    }
}
