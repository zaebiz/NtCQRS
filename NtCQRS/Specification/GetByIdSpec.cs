using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public class GetByIdSpec<TEntity>
        where TEntity : IDbEntity
    {
        public int Id { get; set; }
        public IQueryJoin<TEntity> Join;
    }
}
