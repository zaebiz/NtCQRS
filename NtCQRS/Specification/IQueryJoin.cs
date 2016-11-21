using System.Linq;

namespace NtCQRS.Specification
{
    public interface IQueryJoin<T> where T : IDbEntity
    {
        IQueryable<T> Include(IQueryable<T> src);
    }
}
