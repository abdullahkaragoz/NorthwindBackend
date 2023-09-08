using NorthwindBackend.Core.Utilities.Results;
using NorthwindBackend.Entities.Concrete;
using System.Collections.Generic;

namespace NorthwindBackend.Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<Category> GetById(int productId);
        IDataResult<List<Category>> GetList();
    }
}
