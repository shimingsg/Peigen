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
            ToTable("T_PublicNumber");
            HasKey(m => m.F_PublicID);
            //Property(e => e.F_PublicID).HasColumnName("F_PublicID").IsRequired();
            //Property(e => e.F_PublicName).HasColumnName("F_PublicName").IsRequired();
            //Property(e => e.F_OriginalID).HasColumnName("F_OriginalID").IsRequired();
            //Property(e => e.F_Authentication).HasColumnName("F_Authentication").IsRequired();
            //Property(e => e.F_AppId).HasColumnName("F_AppId").IsRequired();
            //Property(e => e.F_AppSecret).HasColumnName("F_AppSecret").IsRequired();
            //Property(e => e.F_UserID).HasColumnName("F_UserID").IsRequired();
            //Property(e => e.F_NumberType).HasColumnName("F_NumberType").IsRequired();
            //Property(e => e.F_Number).HasColumnName("F_Number").IsRequired();
            //Property(e => e.F_Icon).HasColumnName("F_Icon").IsRequired();
            //Property(e => e.F_Email).HasColumnName("F_Email").IsRequired();
            //Property(e => e.F_Selected).HasColumnName("F_Selected").IsRequired();
            //Property(e => e.F_EncodingAESKey).HasColumnName("F_EncodingAESKey").IsRequired();
            //Property(e => e.F_WorkTime).HasColumnName("F_WorkTime").IsRequired();
            //Property(e => e.F_CreateDate).HasColumnName("F_CreateDate").IsRequired();
        }
    }
}
