using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS.Repository
{
    public interface IRepository
    {
        T GetItemById<T>(int itemId);
        List<T> GetList<T>();
    }

    public class Repository
    {
        private readonly DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }

        private IQueryable<T> GetQueryable<T>() where T : class
            => _db.Set<T>();

        public List<T> GetList<T>(INtJoin<T> join) where T : class
            => GetQueryable<T>()
                .ApplyJoin(join)
                .ToList();

        public List<T> GetFilteredList<T>(INtJoin<T> join, INtSpecification<T> filter) where T : class
            => GetQueryable<T>()
                .ApplyJoin(join)
                .ApplyFilter(filter)
                .ToList();

        public List<T> GetFilteredPagedList<T>(INtJoin<T> join, INtSpecification<T> filter, INtPaging paging) where T : class
            => GetQueryable<T>()
                .ApplyJoin(join)
                .ApplyFilter(filter)
                .ApplyPaging(paging)
                .ToList();

        public List<T> GetOrderedFilteredPagedList<T, V>(INtJoin<T> join, INtSpecification<T> filter, INtPaging paging, INtOrder<T, V> order ) where T : class
            => GetQueryable<T>()
                .ApplyJoin(join)
                .ApplyFilter(filter)
                .ApplyOrder(order)
                .ApplyPaging(paging)
                .ToList();
    }
}
