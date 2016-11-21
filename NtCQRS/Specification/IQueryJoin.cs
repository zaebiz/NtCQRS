using System.Linq;

namespace NtCQRS.Specification
{
    public interface IQueryJoin<T> where T : class
    {
        IQueryable<T> Include(IQueryable<T> src);
    }
}
