using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models;
using NtCQRS.Models.SearchFilters;

namespace NtCQRS.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new RiderService();
            var filter = new RiderFilter()
            {
                RiderName = "Тарас"
            };

            svc.GetRiderList(filter);
            Console.ReadKey();
        }
    }
}
