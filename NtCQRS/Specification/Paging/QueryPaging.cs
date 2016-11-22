using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS.Specification
{
    public class QueryPaging : IQueryPaging
    {
        public QueryPaging() : this(20, 0)
        {}

        public QueryPaging(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Offset => PageSize*PageNumber;
    }
}
