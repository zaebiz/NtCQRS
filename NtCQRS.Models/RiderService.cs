﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Models.JoinSpec;
using NtCQRS.Models.SearchFilters;
using NtCQRS.Query;
using NtCQRS.Specification;

namespace NtCQRS.Models
{
    public class RiderService
    {
        private RacetrackIASEntities _db;

        public RiderService()
        {
            _db = new RacetrackIASEntities();            
        }

        public void GetRiderList(RiderFilter filter)
        {
            var query = new GetListQuery<Riders>(_db)
            {
                Spec = new QuerySpec<Riders>()
                {
                    Filter = filter,
                    Join = new SingleRiderJoinSpec(),
                    Paging = new QueryPaging(50, 0)
                }
            };

            var res = query.GetResult();
            return;
        }

        public void GetRiderById(int riderId)
        {
            var query = new GetByIdQuery<Riders>(_db)
            {
                Spec = new GetByIdSpec<Riders>()
                {
                    Join = new SingleRiderJoinSpec(),
                    Id = riderId
                }
            };

            var res = query.GetResult();
            return;
        }


    }
}
