using API.GClaims.Application;
using API.GClaims.Data.SqlServer.Repositories;
using API.GClaims.Domain.Repositories;
using API.GClaims.Domain.Services;
using API.GClaims.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.GClaims.IoC
{
    public static class Container
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IMarvelService, MarvelService>();
            services.AddScoped<IMarvelRepository, MarvelRepository>();
            services.AddScoped(typeof(MarvelApplication));
           
        }
    }
}
