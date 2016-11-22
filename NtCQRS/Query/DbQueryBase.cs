using System;
using System.Data.Entity;
using System.Linq;
using NtCQRS.Repository;

namespace NtCQRS.Query
{
    

    // третий вариант как некий микс 1  и 2 случаев
    // инстанцируем прямо в сервисе
    // для кастомных операций Execute без параметров - но как тогда передать какие либо параметры в эти операции
    // для GetById() тоже неясно что делать
    // возможно стандартные запросы надо инстанциировать прямо в сервисах (создавать экземпляр шаблонного класса)
    // для кастомных запросов создаем отдельные классы заранее

    // в базовый класс вынесем простые методы - создание и инициализация св-в, GetById,
    // от него унаследуем нижние классы
    public class DbQueryBase<TEntity> where TEntity : IDbEntity
    {
        protected DbContext _context;
        protected IRepository _db;

        protected DbQueryBase(DbContext ctx)
        {
            _context = ctx;
            _db = new NtRepository(ctx);
        }

        protected virtual IQueryable<TEntity> Execute()
        {
            throw new NotImplementedException();
        }
    }
    
}
