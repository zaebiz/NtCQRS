using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NtCQRS.Repository;
using NtCQRS.Specification;

namespace NtCQRS.Query
{
    /// <summary>
    /// класс для запросов сущностей из БД списком
    /// Spec - параметры запроса (фильтрация, пагинация)
    /// можно не наследоваться, а инстанцировать прямо в коде, указывая конкретный тип
    /// </summary>
    public class GetListQuery<TEntity>
        : DbQueryBase
        , IDbQuery<List<TEntity>, QuerySpec<TEntity>> 
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Присоединять ли полученные сущности к контексту
        /// </summary>
        public bool AttachResultToContext { get; set; } = false;
        
        public GetListQuery(DbContext ctx) : base(ctx)
        {
            Spec = new QuerySpec<TEntity>();
        }

        protected virtual IQueryable<TEntity> Execute()
        {
            var queryable = _db.GetList(Spec);
            if (!AttachResultToContext)
                queryable = queryable.AsNoTracking();

            return queryable;
        }


        #region IQuery members

        public QuerySpec<TEntity> Spec { get; set; }

        public List<TEntity> GetResult()
            => Execute().ToList();

        public async Task<List<TEntity>> GetResultAsync()
            => await Execute().ToListAsync();

        #endregion

    }
}