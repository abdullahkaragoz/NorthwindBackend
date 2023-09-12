using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
