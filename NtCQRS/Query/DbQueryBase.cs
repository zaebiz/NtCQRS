using System;
using System.Data.Entity;
using System.Linq;
using NtCQRS.Command;
using NtCQRS.Repository;

namespace NtCQRS.Query
{
    /// <summary>
    /// базовый класс для запросов (Queries) к БД
    /// в данный момент аналог DbCommandBase
    /// </summary>
    public class DbQueryBase : DbCommandBase
    {
        public DbQueryBase(DbContext ctx) : base(ctx)
        {
            ctx.Configuration.AutoDetectChangesEnabled = false;            
        }
    }
    
}
