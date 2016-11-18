using NtCQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS
{
    class NtQueryBase //: INtQuery<>
    {
        private RacetrackIASEntities _db;

        public NtQueryBase()
        {
            _db = new RacetrackIASEntities();
        }


    }
}
