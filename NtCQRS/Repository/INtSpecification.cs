using System.Linq;

namespace NtCQRS.Repository
{
    public interface INtSpecification<T> where T : class
    {
        IQueryable<T> GetSatisfiedItems(IQueryable<T> src);
    }
}
