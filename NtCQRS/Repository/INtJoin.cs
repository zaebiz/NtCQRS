using System.Linq;

namespace NtCQRS.Repository
{
    public interface INtJoin<T> where T : class
    {
        IQueryable<T> Include(IQueryable<T> src);
    }
}
