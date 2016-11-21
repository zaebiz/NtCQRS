using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS.Models.Filters
{
    public class RiderFilterParams
    {
        public int RiderId { get; set; }
        public string RiderName { get; set; }
    }

    public class RiderFilter
    {
        public int RiderId { get; set; }
        public string RiderName { get; set; }
    }
}
