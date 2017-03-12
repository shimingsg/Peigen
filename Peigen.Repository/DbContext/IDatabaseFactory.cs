using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public interface IDatabaseFactory:IDisposable
    {
        DataBaseContext Get();
    }
}
