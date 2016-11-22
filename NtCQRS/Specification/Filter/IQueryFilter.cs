using System.Linq;
using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public interface IQueryFilter<TEntity> where TEntity : IDbEntity
    {
        IQueryable<TEntity> GetSatisfiedItems(IQueryable<TEntity> src);
    }
}
