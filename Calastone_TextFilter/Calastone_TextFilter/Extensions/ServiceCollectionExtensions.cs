using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Factories;
using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Services;

namespace TextFilter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTextFilterServices (this IServiceCollection services) 
        {
            services.AddScoped<IinterogationService, InterrogationService>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddSingleton<Func<IEnumerable<ITextFilter>>>(
                x => () => x.GetService<IEnumerable<ITextFilter>>()!);
            services.AddSingleton<IFilterFactory, FilterFactory>();
            services.AddScoped<ITextFilter, Filter1>();
            services.AddScoped<ITextFilter, Filter2>();
            services.AddScoped<ITextFilter, Filter3>();
            return services;

        }
    }
}
