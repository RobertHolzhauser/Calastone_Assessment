using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Factories;
using TextFilter.Filters;
using TextFilter.Interfaces;

namespace TextFilter.Tests
{
    // https://github.com/pengweiqhca/Xunit.DependencyInjection/blob/main/README.md
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<Func<IEnumerable<ITextFilter>>>
                    (x => () => x.GetService<IEnumerable<ITextFilter>>()!);
            services.AddSingleton<IFilterFactory, FilterFactory>();
            services.AddScoped<ITextFilter, Filter1>();
            services.AddScoped<ITextFilter, Filter2>();
            services.AddScoped<ITextFilter, Filter3>();
        }
    }
}
