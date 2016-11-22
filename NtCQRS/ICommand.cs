using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS
{
    public interface INtCommand<TParam, TResult>
    {
        TResult Execute(TParam data);
        Task<TResult> ExecuteAsync(TParam data);
    }

    //public interface INtAsyncCommand<Tin, Tout> : INtCommand<Tin, Task<Tout>>
    //{}
    

}
