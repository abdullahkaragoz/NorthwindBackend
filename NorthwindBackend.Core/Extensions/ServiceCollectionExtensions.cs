using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        };
    }
}
