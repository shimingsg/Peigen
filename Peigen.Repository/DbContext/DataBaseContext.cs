using Peigen.Domain.Entities;
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

        public DbSet<PublicNumberEntity> PublicNumberDbSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PublicNumberMap());
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<PublicNumberEntity>().MapToStoredProcedures().ToTable("T_PublicNumber");
        }
    }
}
