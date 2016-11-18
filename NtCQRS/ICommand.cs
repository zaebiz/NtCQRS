using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS
{
    public interface INtCommand<Tin, Tout>
    {
        Tout Execute(Tin data);
    }

    public interface INtAsyncCommand<Tin, Tout> : INtCommand<Tin, Task<Tout>>
    {}
    

}
