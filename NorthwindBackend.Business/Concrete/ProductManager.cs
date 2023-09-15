using Microsoft.AspNetCore.Http;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Business.BusinessAspect;
using NorthwindBackend.Business.Constants;
using NorthwindBackend.Business.ValidationRules.FluentValidation;
using NorthwindBackend.Core.Aspects.Autofac.Caching;
using NorthwindBackend.Core.Aspects.Autofac.Transaction;
using NorthwindBackend.Core.Aspects.Autofac.Validation;
using NorthwindBackend.Core.Extensions;
using NorthwindBackend.Core.Utilities.Results;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindBackend.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        [SecuredOperation("Product.List,Admin")]
        [CacheAspect(10)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            //  _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
