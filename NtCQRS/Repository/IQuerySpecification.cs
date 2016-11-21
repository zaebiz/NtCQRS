using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Repository
{
    // todo - можно переделать в класс
    public class QuerySpecification<T> where T : class 
    {
        public QuerySpecification()
        {
            Paging = new QueryPaging(20, 0);
        }

        public IQueryFilter<T> Filter { get; set; }
        public IQueryJoin<T> Join { get; set; }
        public IQueryPaging Paging { get; set; }
    }

    public class OrderedQuerySpecification<T, V> where T : class
    {
        public OrderedQuerySpecification()
        {
            Spec = new QuerySpecification<T>();
        }

        public QuerySpecification<T> Spec;
        public IQueryOrder<T, V> Order { get; set; }
    }


}
