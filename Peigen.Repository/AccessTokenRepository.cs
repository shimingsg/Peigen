using Peigen.Domain.Entities;
using Peigen.Domain.IEntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public class AccessTokenRepository : RepositoryBase<AccessTokenEntity>, IAccessTokenRepository
    {
        public AccessTokenRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }
    }
}
