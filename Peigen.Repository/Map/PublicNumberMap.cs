using Peigen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public class PublicNumberMap: EntityTypeConfiguration<PublicNumberEntity>
    { 
        public PublicNumberMap()
        {            
            HasKey(m => m.F_PublicID);
            Property(e => e.F_PublicID).HasColumnName("F_PublicID");
            ToTable("T_PublicNumber");
        }
    }
}
