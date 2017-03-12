using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DataBaseContext dataContext;
        public DataBaseContext Get()
        {
            return dataContext ?? (dataContext = new DataBaseContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
