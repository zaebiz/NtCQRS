using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;
using NtCQRS.Specification;

namespace NtCQRS
{
    public interface INtQuery<TEntity> 
        where TEntity : IDbEntity
    {
        List<TEntity> GetResult();
        Task<List<TEntity>> GetResultAsync();
    }

    //public interface INtQuery<TEntity, TSortKey> 
    //    : INtQuery<TEntity>
    //    where TEntity : class
    //{
    //    TEntity Execute(INtFilter<TEntity> spec);
    //}
}
