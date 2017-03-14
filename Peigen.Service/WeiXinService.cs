using Peigen.Domain.Entities;
using Peigen.Domain.IEntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Service
{
    public class WeiXinService: IWeiXinService
    {
        private readonly IPublicNumberRepository _publicNumberRepository;
        public WeiXinService(IPublicNumberRepository publicNumberRepository)
        {
            _publicNumberRepository = publicNumberRepository;
        }

        public PublicNumberEntity GetById(int id)
        {
            return _publicNumberRepository.GetById(id);          
        }

        public List<PublicNumberEntity> GetMany(int type) 
        {
           return _publicNumberRepository.GetMany(p => p.F_NumberType == type).ToList();            
        }
    }
}
