using Peigen.Domain.Entities;
using Peigen.Domain.IEntityRepository;
using Peigen.Repository;
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
        private readonly PTest test = new PTest();
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

        public PublicNumberEntity Add(int id)
        {
            var entity = _publicNumberRepository.GetById(id);
            _publicNumberRepository.Add(entity);
            _publicNumberRepository.Save();
            return entity;
        }

        public PublicNumberEntity AddModel(PublicNumberEntity model)
        {
            return model;
        }

        public PublicNumberEntity GetById2(int Id)
        {
           return test.Get(x => x.F_PublicID == Id);
        }
    }
}
