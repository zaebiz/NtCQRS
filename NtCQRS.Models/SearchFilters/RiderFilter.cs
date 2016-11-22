using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Specification;

namespace NtCQRS.Models.Filters
{
    public class RiderFilter : QueryFilterBase<Riders>
    {
        public int RiderId { get; set; }
        public string RiderName { get; set; }
    }
}
