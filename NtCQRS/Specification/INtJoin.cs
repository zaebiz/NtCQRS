using System.Linq;

namespace NtCQRS.Specification
{
    public interface INtJoin<T> where T : class
    {
        IQueryable<T> Include(IQueryable<T> src);
    }
}
