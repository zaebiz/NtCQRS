using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS.Repository
{
    public interface INtOrder<T, V> where T : class
    {
        int Direction { get; set; }
        Func<T, V> Expression { get; set; }
    }
}
