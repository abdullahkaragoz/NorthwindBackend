using NorthwindBackend.Core.DataAccess;
using NorthwindBackend.Core.Entities.Concrete;
using NorthwindBackend.Entities.Concrete;
using System.Collections.Generic;

namespace NorthwindBackend.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
