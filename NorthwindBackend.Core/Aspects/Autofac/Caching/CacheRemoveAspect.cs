using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.Core.CrossCuttingConcerns.Caching;
using NorthwindBackend.Core.Utilities.Interceptors;
using NorthwindBackend.Core.Utilities.IoC;

namespace NorthwindBackend.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
