using System.Collections.Generic;
using System.Threading.Tasks;

namespace NtCQRS.Query
{
    public interface INtQuery<TEntity> 
        where TEntity : IDbEntity
    {
        List<TEntity> GetResult();
        Task<List<TEntity>> GetResultAsync();
    }

    //public interface INtQuery<TEntity, TSortKey> 
    //    : INtQuery<TEntity>
    //    where TEntity : class
    //{
    //    TEntity Execute(INtFilter<TEntity> spec);
    //}

    // это попытка дальнейшего развития идеи которая была в Racetrack
    // есть объекты запросов, инкапсулирующие все что можно
    // мы изначально создаем классы - отдельные объекты запросов, 
    // которым потом во время выполнения передаем спецификацию запроса (фильтр, джоин, панинатор, ордер)
    // логика самого запроса перегружается в методе ExecuteQuery
    // ? как быть с запросами получения по Id? фильтр городить не хочется
    // ? как писать кастомные запросы, получающие не стандартные результаты, а то чего нет в DbSet-ах, напрмер агрегацию
    // rfcnjvyst
    //class NtQueryBase<TEntity> 
    //    : INtQuery<TEntity> where TEntity : IDbEntity
    //{
    //    protected RacetrackIASEntities _context;
    //    protected IRepository _db;
    //    protected IQueryable<TEntity> _executeResult;

    //    /// <summary>
    //    /// какие связи нужны для подключаемой сущности
    //    /// </summary>
    //    public IQueryJoin<TEntity> Join { get; set; }

    //    /// <summary>
    //    /// фильтрация запроса
    //    /// </summary>
    //    public IQueryFilter<TEntity> Filter { get; set; }

    //    /// <summary>
    //    /// пагинация запроса
    //    /// </summary>
    //    public IQueryPaging Paging { get; set; }

    //    public NtQueryBase()
    //    {
    //        _context = new RacetrackIASEntities();
    //        _db = new NtRepository(_context);
    //    }

    //    /// <summary>
    //    /// получить результат запроса синхронно
    //    /// </summary>        
    //    public List<TEntity> GetResult()
    //    {
    //        return ExecuteQuery()
    //            .ToList();
    //    }

    //    /// <summary>
    //    /// получить результат запроса Асинхронно
    //    /// </summary>
    //    public async Task<List<TEntity>> GetResultAsync()
    //    {
    //        return await ExecuteQuery()
    //            .ToListAsync();
    //    }

    //    protected virtual IQueryable<TEntity> ExecuteQuery()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    //class NtRiderQuery : NtQueryBase<Riders>
    //{
    //    public NtRiderQuery()
    //    {
    //        Join = new StandartJoinBehaviour();
    //        Paging = new QueryPagingBase();
    //    }

    //    protected override IQueryable<Riders> ExecuteQuery()
    //    {
    //        return _db.GetFilteredList(Join, Filter);
    //    }

    //    class StandartJoinBehaviour : IQueryJoin<Riders>
    //    {
    //        public IQueryable<Riders> Include(IQueryable<Riders> src)
    //           => src
    //                .Include(x => x.RaceResults)
    //                .Include(x => x.RaceClaims);
    //    }
    //}

    // это попытка реализовать CQRS по статье на хабре
    // https://habrahabr.ru/post/313110/
    // создаем кучу шаблонных классов различных типов запросов (Query, AsyncQuery, AsyncFilteredQuery, AsymcFilteredPaginatedQuery...)
    // в сервисах непосредственно инстанциируем шаблонные классы нужного нам типа
    // через конструктор (или как св-ва) устанавливаем параметры запроса - напрмер передаем ISpecification
    // и получаем результат

    // тут можно создать Query c параметров Action<TResult> и писать любые запросы, изза которыхраньше приходилось расширять интерефйс
    // повторное использование будет достигаться тем, что это будет обернуто сервисами
    // либо наоборот вешеописанные запросы не инстанциировать конкретно, а писать (создавать классы) заранее
    //public interface IQuery2<TEntity>
    //{
    //    TEntity Execute();
    //}

    //public interface IAsyncQuery2<TEntity>
    //    : IQuery2<Task<TEntity>>
    //{}

    //public interface IQuery2<TEntity, TSpecification>
    //{
    //    TEntity Execute(TSpecification spec);
    //}

    //public interface IAsyncQuery2<TEntity, TSpecification>
    //    : IQuery2<Task<TEntity>, TSpecification>
    //{}

    //public class BaseQuery2<TEntity> : IQuery2<TEntity, QuerySpecification<TEntity>>
    //    where TEntity : IDbEntity
    //{
    //    protected DbContext _context;
    //    protected IRepository _db;

    //    public BaseQuery2(DbContext ctx)
    //    {
    //        _context = ctx;
    //        _db = new NtRepository(ctx);
    //    }

    //    public TEntity Execute(QuerySpecification<TEntity> spec)
    //    {
    //        return _db.GetFilteredList(spec.Join, spec.Filter);
    //    }
    //}
}
