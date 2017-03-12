using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("MicroWeiXin_DB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
