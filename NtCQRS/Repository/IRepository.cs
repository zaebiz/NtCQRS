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
        TEntity GetItemById<TEntity>(GetByIdSpec<TEntity> spec) where TEntity : class, IDbEntity;
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

        private IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class, IDbEntity
            => _db.Set<TEntity>();

        /// <summary>
        /// получить сущность по Id
        /// </summary>
        public TEntity GetItemById<TEntity>(GetByIdSpec<TEntity> spec) where TEntity : class, IDbEntity
            => GetQueryable<TEntity>()
                .ApplyJoin(spec.Join)
                .FirstOrDefault(x => x.Id == spec.Id);        

        /// <summary>
        /// получить список сущностей по "спецификации" - набору правил описывающему:
        /// Join (какие таблицы присоединять к результату запроса)
        /// Filter (набор Where-предикатов, фильтрующих сущности)
        /// Paging (параметры пагинации запроса)
        /// </summary>
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

        /// <summary>
        /// получить список сущностей по "спецификации" - набору правил описывающему:
        /// Join (какие таблицы присоединять к результату запроса)
        /// Filter (набор Where-предикатов, фильтрующих сущности)
        /// Paging (параметры пагинации запроса)
        /// Order (правило сортировки результата)
        /// </summary>
        public IQueryable<TEntity> GetOrderedList<TEntity, TSortKey>(OrderedQuerySpec<TEntity, TSortKey> spec)
            where TEntity : class, IDbEntity
        {
            if (spec.Order == null)
                throw new Exception("Не указана сортировка. Используйте QuerySpecification<>");

            return GetList<TEntity>(spec.Spec)
                .ApplyOrder(spec.Order);
        }

        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : class, IDbEntity
        {
            bool entityExist = entity.Id > 0;

            _db.Entry(entity).State = entityExist
                ? EntityState.Modified
                : EntityState.Added;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }


    }
}
