using System.Threading.Tasks;

namespace NtCQRS.Query
{
    public interface IDbQuery<TEntity, TSpecification> where TEntity : class
    {
        TSpecification Spec { get; set; }

        TEntity GetResult();
        Task<TEntity> GetResultAsync();
    }

    // todo можно декомпозировать еще сильнее, разделив синхронные и асинхронные команды
    // например
}