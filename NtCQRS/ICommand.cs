using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS
{
    public interface IDbCommand<TParam, TResult>
    {
        TResult Execute(TParam data);
        Task<TResult> ExecuteAsync(TParam data);
    }

    public class DbCommandBase
    {
        protected DbContext _context;
        protected IRepository _db;

        protected DbCommandBase(DbContext ctx)
        {
            _context = ctx;
            _db = new NtRepository(ctx);
        }
    }



    //public interface INtAsyncCommand<Tin, Tout> : INtCommand<Tin, Task<Tout>>
    //{}
    

}
