using System.Linq;

namespace NtCQRS.Specification
{
    public interface IQueryFilter<T> where T : class
    {
        IQueryable<T> GetSatisfiedItems(IQueryable<T> src);
    }
}
