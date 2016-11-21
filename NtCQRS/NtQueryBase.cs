using NtCQRS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;
using NtCQRS.Specification;

namespace NtCQRS
{
    class NtQueryBase<TEntity> 
        : INtQuery<TEntity> where TEntity : class
    {
        protected RacetrackIASEntities _context;
        protected IRepository _db;
        protected IQueryable<TEntity> _executeResult;

        /// <summary>
        /// какие связи нужны для подключаемой сущности
        /// </summary>
        public IQueryJoin<TEntity> Join { get; set; }

        /// <summary>
        /// фильтрация запроса
        /// </summary>
        public IQueryFilter<TEntity> Filter { get; set; }

        /// <summary>
        /// пагинация запроса
        /// </summary>
        public IQueryPaging Paging { get; set; }

        public NtQueryBase()
        {
            _context = new RacetrackIASEntities();
            _db = new NtRepository(_context);
        }

        /// <summary>
        /// получить результат запроса синхронно
        /// </summary>        
        public List<TEntity> GetResult()
        {
            return ExecuteQuery()
                .ToList();
        }

        /// <summary>
        /// получить результат запроса Асинхронно
        /// </summary>
        public async Task<List<TEntity>> GetResultAsync()
        {
            return await ExecuteQuery()
                .ToListAsync();
        }

        protected virtual IQueryable<TEntity> ExecuteQuery()
        {
            throw new NotImplementedException();
        }
    }

    // это попытка дальнейшего развития идеи которая была в Racetrack
    // есть объекты запросов, инкапсулирующие все что можно
    // мы изначально создаем классы - отдельные объекты запросов, 
    // которым потом во время выполнения передаем спецификацию запроса (фильтр, джоин, панинатор, ордер)
    // логика самого запроса перегружается в методе ExecuteQuery
    // ? как быть с запросами получения по Id? фильтр городить не хочется
    // ? как писать кастомные запросы, получающие не стандартные результаты, а то чего нет в DbSet-ах, напрмер агрегацию
    // rfcnjvyst
    class NtRiderQuery : NtQueryBase<Riders>
    {
        public NtRiderQuery()
        {
            Join = new StandartJoinBehaviour();
            Paging = new QueryPagingBase();
        }

        protected override IQueryable<Riders> ExecuteQuery()
        {
            return _db.GetFilteredList(Join, Filter);
        }

        class StandartJoinBehaviour : IQueryJoin<Riders>
        {
            public IQueryable<Riders> Include(IQueryable<Riders> src)
               => src
                    .Include(x => x.RaceResults)
                    .Include(x => x.RaceClaims);
        }
    }

    // это попытка реализовать CQRS по статье на хабре
    // https://habrahabr.ru/post/313110/
    // создаем кучу шаблонных классов различных типов запросов (Query, AsyncQuery, AsyncFilteredQuery, AsymcFilteredPaginatedQuery...)
    // в сервисах непосредственно инстанциируем шаблонные классы нужного нам типа
    // через конструктор (или как св-ва) устанавливаем параметры запроса - напрмер передаем ISpecification
    // и получаем результат

    // тут можно создать Query c параметров Action<TResult> и писать любые запросы, изза которыхраньше приходилось расширять интерефйс
    // повторное использование будет достигаться тем, что это будет обернуто сервисами
    // либо наоборот вешеописанные запросы не инстанциировать конкретно, а писать (создавать классы) заранее
    public interface IQuery2<TEntity>
    {
        TEntity Execute();
    }

    public interface IAsyncQuery2<TEntity>
        : IQuery2<Task<TEntity>>
    {}

    public interface IQuery2<TEntity, TSpecification>
    {
        TEntity Execute(TSpecification spec);
    }

    public interface IAsyncQuery2<TEntity, TSpecification>
        : IQuery2<Task<TEntity>, TSpecification>
    {}

    public class BaseQuery2<TEntity> : IQuery2<TEntity, QuerySpecification<TEntity>>
        where TEntity : class
    {
        protected DbContext _context;
        protected IRepository _db;

        public BaseQuery2(DbContext ctx)
        {
            _context = ctx;
            _db = new NtRepository(ctx);
        }

        public TEntity Execute(QuerySpecification<TEntity> spec)
        {
            return _db.GetFilteredList(spec.Join, spec.Filter)
        }
    }

    // третий вариант как некий микс 1  и 2 случаев
    // инстанцируем прямо в сервисе
    // для кастомных операций Execute без параметров - но как тогда передать какие либо параметры в эти операции
    // для GetById() тоже неясно что делать
    // возможно стандартные запросы надо инстанциировать прямо в сервисах (создавать экземпляр шаблонного класса)
    // для кастомных запросов создаем отдельные классы заранее

    public interface IQuery3<TEntity, TSpecification> where TEntity : class
    {
        TSpecification Spec { get; set; }

        //List<TEntity> GetResult();
        //Task<List<TEntity>> GetResultAsync();

        TEntity GetResult();
        Task<TEntity> GetResultAsync();

    }

    // в базовый класс вынесем простые методы - создание и инициализация св-в, GetById,
    // от него унаследуем нижние классы
    public class Query3Base<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected IRepository _db;

        protected Query3Base(DbContext ctx)
        {
            _context = ctx;
            _db = new NtRepository(ctx);
        }

        protected virtual IQueryable<TEntity> Execute()
        {
            throw new NotImplementedException();
        }

        //public TEntity GetById(int itemId)
        //{
        //    return _db.GetItemById<TEntity>(itemId);
        //}
    }

    // этот класс инстанциируем прямо в сервисах. используеи предопределенный IQuerySpecification
    public class Query3<TEntity>
        : Query3Base<TEntity>
        , IQuery3<List<TEntity>, QuerySpecification<TEntity>> 
        where TEntity : class
    {
        public Query3(DbContext ctx) : base(ctx)
        {
            Spec = new QuerySpecification<TEntity>();
        }

        protected override IQueryable<TEntity> Execute()
            => _db.GetList(Spec);


        #region IQuery members

        public QuerySpecification<TEntity> Spec { get; set; }

        public List<TEntity> GetResult()
            => Execute().ToList();

        public async Task<List<TEntity>> GetResultAsync()
            => await Execute().ToListAsync();
        #endregion

    }

    // класс получения списка элементов с сортировкой
    public class OrderedQuery3<TEntity, TSortKey>
        : Query3<TEntity>
        , IQuery3<List<TEntity>, OrderedQuerySpecification<TEntity, TSortKey>>
        where TEntity : class
    {
        public OrderedQuery3(DbContext db) : base(db)
        {
            // todo инициализировать Spec с помощью фабрики
            //Spec = new 
        }

        public new OrderedQuerySpecification<TEntity, TSortKey> Spec { get; set; }

        protected override IQueryable<TEntity> Execute()
            => _db.GetOrderedList(Spec);
    }

    // класс получающий 1 элемент
    public class GetByIdQuery<TEntity>
       : Query3Base<TEntity>
       , IQuery3<TEntity, int>
       where TEntity : class
    {
        public GetByIdQuery(DbContext ctx) : base(ctx)
        {
        }

        public int Spec { get; set; }

        public TEntity GetResult()
            => _db.GetItemById<TEntity>(Spec);

        public async Task<TEntity> GetResultAsync()
         => await Task.FromResult(GetResult());
    }


}
