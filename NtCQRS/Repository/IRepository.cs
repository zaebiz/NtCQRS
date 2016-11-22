using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Repository
{
    public interface IRepository
    {
        TEntity GetItemById<TEntity>(int itemId) where TEntity : class, IDbEntity;
        //IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : IDbEntity;
        IQueryable<TEntity> GetList<TEntity>(QuerySpec<TEntity> spec) where TEntity : class, IDbEntity;
        IQueryable<TEntity> GetOrderedList<TEntity, TSortKey>(OrderedQuerySpec<TEntity, TSortKey> spec) where TEntity : class, IDbEntity;
    }

    public class NtRepository : IRepository
    {
        private readonly DbContext _db;

        public NtRepository(DbContext db)
        {
            _db = db;
            _db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public TEntity GetItemById<TEntity>(int id/*, INtJoin<TEntity> join*/) where TEntity : class, IDbEntity
            => _db.Set<TEntity>()
                .Find(id);

        private IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class, IDbEntity
            => _db.Set<TEntity>();

        public IQueryable<TEntity> GetList<TEntity>(QuerySpec<TEntity> spec) where TEntity : class, IDbEntity
        {
            var queryable = GetQueryable<TEntity>()
                .ApplyJoin(spec.Join)
                .ApplyFilter(spec.Filter);

            if (spec.Paging != null)    // пейджинг без сортировки не работает
                queryable = queryable.ApplyOrder(spec.DefaultOrder);

            return queryable
                .ApplyPaging(spec.Paging);
        }
             

        public IQueryable<TEntity> GetOrderedList<TEntity, TSortKey>(OrderedQuerySpec<TEntity, TSortKey> spec)
            where TEntity : class, IDbEntity
        {
            if (spec.Order == null)
                throw new Exception("Не указана сортировка. Используйте QuerySpecification<>");

            return GetList<TEntity>(spec.Spec)
                .ApplyOrder(spec.Order);
        }

        
    }
}
