using System.Linq;

namespace NtCQRS.Specification
{
    public interface INtFilter<T> where T : class
    {
        IQueryable<T> GetSatisfiedItems(IQueryable<T> src);
    }
}
