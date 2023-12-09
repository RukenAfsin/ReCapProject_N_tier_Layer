using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //servis bagımlıklıklarını eklediğimiz:servicecollection.core katmanında ekliceğimiz tüm injectionları bi arada toplamamızı sağladı
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);

            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
