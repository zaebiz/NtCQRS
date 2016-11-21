using System;

namespace NtCQRS.Specification
{
    public interface IQueryOrder<T, V> where T : class
    {
        int Direction { get; set; }
        Func<T, V> Expression { get; set; }
    }
}
