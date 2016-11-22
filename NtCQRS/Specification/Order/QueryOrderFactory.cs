using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS.Specification
{
    public class QueryOrderFactory<TEntity> where TEntity : IDbEntity
    {
        public static IQueryOrder<TEntity, TColumn> Create<TColumn>(Func<TEntity, TColumn> expression, int direction = 0)
        {
            return new QueryOrderBase<TEntity, TColumn>()
            {
                Expression = expression,
                Direction = direction
            };
        }

        public static IQueryOrder<TEntity, int> Create()
        {
            return Create(x => x.Id);
        }
    }
}
