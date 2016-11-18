using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS.Specification
{
    public class NtPagingBase : INtPaging
    {
        public NtPagingBase()
        {
            PageSize = 20;
            PageNumber = 0;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int Offset => PageSize*PageSize;
    }
}
