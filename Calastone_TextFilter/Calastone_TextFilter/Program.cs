using System.Collections;
using TextFilter.Interfaces;
using TextFilter.Main;
using TextFilter.Services;
using TextFilter.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace TextFilter
{
    internal class Program
    {
        /***
         * TextFiler App
         * we get the path to the input file from args[0]
         * args[1] = optional parameter to discard punctuation.  "discard" => ditch punctuation.  default is to keep punctuation.  
         * We might want to create a help menu for the parameters
         **/
        static void Main(string[] args)
        {

            if (args.Length == 0) { throw new ArgumentNullException("File Path is missing"); }
            Console.WriteLine($"The input file path is {args[0]}");

            string filepath = args[0];
            bool keepPunctuation = true;
            if (args[1] != null && (args[1].ToLower() == "discard")) { keepPunctuation = false; }

            // set up dependency injection
            var services = new ServiceCollection();
            services.AddScoped<IinterogationService, InterogationService>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddScoped<ITextFilter, Filter1>();
            services.AddScoped<ITextFilter, Filter2>();
            services.AddScoped<ITextFilter, Filter3>();
            var provider = services.BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true });  // catch missing registrations at startup, rather than runtime
            using var scope = provider.CreateScope();

            var interogation = scope.ServiceProvider.GetRequiredService<IinterogationService>();
            var reader = scope.ServiceProvider.GetRequiredService<IFileReader>();

            var app = new App(filepath, keepPunctuation, interogation, reader);
            app.Run();
        }
         
    }
}
