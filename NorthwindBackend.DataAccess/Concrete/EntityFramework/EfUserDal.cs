using NorthwindBackend.Core.DataAccess.EntityFramework;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.DataAccess.Concrete.EntityFramework.Contexts;
using NorthwindBackend.Core.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NorthwindBackend.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var _context = new NorthwindContext())
            {
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };


                return result.ToList();
            }
        }
    }
}
