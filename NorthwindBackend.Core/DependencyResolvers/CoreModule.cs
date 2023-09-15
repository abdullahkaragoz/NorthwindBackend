using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.Core.CrossCuttingConcerns.Caching;
using NorthwindBackend.Core.CrossCuttingConcerns.Caching.Microsoft;
using NorthwindBackend.Core.Utilities.IoC;

namespace NorthwindBackend.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
