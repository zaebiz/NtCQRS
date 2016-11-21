using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS
{
    public class DbEntityBase : IDbEntity
    {
        public int Id { get; set; }
    }
}
