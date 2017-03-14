using Peigen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Service
{
    public interface IWeiXinService
    {
        PublicNumberEntity GetById(int id);
        List<PublicNumberEntity> GetMany(int type);
    }
}
