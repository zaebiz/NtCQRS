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
    public interface INtRepository
    {
        TEntity GetItemById<TEntity>(int itemId) where TEntity : class;
        //IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetList<TEntity>(QuerySpecification<TEntity> spec) where TEntity : class;
        IQueryable<TEntity> GetOrderedList<TEntity, TSortKey>(OrderedQuerySpecification<TEntity, TSortKey> spec) where TEntity : class;
    }

    public class NtRepository : INtRepository
    {
        private readonly DbContext _db;

        public NtRepository(DbContext db)
        {
            _db = db;
        }

        public TEntity GetItemById<TEntity>(int id/*, INtJoin<TEntity> join*/) where TEntity : class
            => _db.Set<TEntity>()
                .Find(id);

        private IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
            => _db.Set<TEntity>();

        public IQueryable<TEntity> GetList<TEntity>(QuerySpecification<TEntity> spec) where TEntity : class
        {
            return GetQueryable<TEntity>()
                .ApplyJoin(spec.Join)
                .ApplyFilter(spec.Filter)
                .ApplyPaging(spec.Paging);
        }
             

        public IQueryable<TEntity> GetOrderedList<TEntity, TSortKey>(OrderedQuerySpecification<TEntity, TSortKey> spec)
            where TEntity : class
        {
            return GetList<TEntity>(spec.Spec)
                .ApplyOrder(spec.Order);
        }

        
    }
}
