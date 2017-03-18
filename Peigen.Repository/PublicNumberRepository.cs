/*------------------------------------------------ 
// File Name:PublicNumber.cs 
// File Description:PublicNumber DataBase EntityRepository 
// Author:Gen 
// Create Time:2017/03/12 14:15:33 
//------------------------------------------------*/  
using System;
using Peigen.Domain.Entities;
using Peigen.Domain.IEntityRepository;
 
namespace Peigen.Repository
{
    public class PublicNumberRepository:RepositoryBase<PublicNumberEntity>, IPublicNumberRepository
    {
        public PublicNumberRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }


    }
}