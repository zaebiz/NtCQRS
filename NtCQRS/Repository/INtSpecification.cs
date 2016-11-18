using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Repository
{
    public interface INtSpecification<T> where T : class 
    {
        INtFilter<T> Filter { get; set; }
        INtJoin<T> Join { get; set; }
        INtPaging Paging { get; set; }
    }
}
