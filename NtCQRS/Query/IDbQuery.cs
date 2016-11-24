using System.Threading.Tasks;

namespace NtCQRS.Query
{
    /// <summary>
    /// Тип "запрос" (Query) - операция возвращающая данные 
    /// не имеет права ничего менять 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TSpecification"></typeparam>
    public interface IDbQuery<TEntity, TSpecification> where TEntity : class
    {
        TSpecification Spec { get; set; }

        TEntity GetResult();
        Task<TEntity> GetResultAsync();
    }

    // todo можно декомпозировать еще сильнее, разделив синхронные и асинхронные команды, например
    //public interface IDbQuery<out TEntity, TSpecification> 
    //    where TEntity : class
    //{
    //    TSpecification Spec { get; set; }
    //    TEntity GetResult();
    //}

    //public interface IDbAsyncQuery<TEntity, TSpecification> 
    //    : IDbQuery<Task<TEntity>, TSpecification>
    //    where TEntity : class
    //{
    //}
}