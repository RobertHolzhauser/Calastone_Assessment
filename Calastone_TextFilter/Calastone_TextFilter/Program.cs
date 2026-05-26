using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using TextFilter.Extensions;
using TextFilter.Factories;
using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Main;
using TextFilter.Services;

namespace TextFilter
{
    internal class Program
    {
        /***
         * TextFiler App
         * we get the path to the input file from args[0]
         * *** NOT FULLY IMPLEMENTED args[1] = optional parameter to ignore, count puncuation as char, disgard (delete), or interogate punctuation to keep it.  
         *   the default behavior is to count punctuation as char.  // TODO review implmentation
         * We might want to create a help menu for the parameters
         **/
        static void Main(string[] args)
        {

            if (args.Length == 0) { throw new ArgumentNullException("File Path is missing"); }
            //Console.WriteLine($"The input file path is {args[0]}");

            string filepath = args[0];
            string punctuationHandle = "count";   // ignore will skip over punctuation - not counting it as
            if (args.Length >= 2) 
            {
                switch (args[1]) 
                {
                    /***  not fully implemented
                    case "disgard":
                        punctuationHandle = "discard";  // this will delete punctuation
                        break;
                    case "ignore":
                        punctuationHandle = "ignore";  // this will count punctuation as a letter
                        break;
                    case "interrogate":
                        punctuationHandle = "interrogate";
                        break;
                    **/
                    default:
                        punctuationHandle = "count";   // default counts punctuation as letters
                        break;
                }
            }

            // set up dependency injection
            var services = new ServiceCollection().AddTextFilterServices();

            var provider = services.BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true });  // catch missing registrations at startup, rather than runtime
            using var scope = provider.CreateScope();

            var interogation = scope.ServiceProvider.GetRequiredService<IinterogationService>();
            var reader = scope.ServiceProvider.GetRequiredService<IFileReader>();
            var filterFactory = scope.ServiceProvider.GetRequiredService<IFilterFactory>();

            // Launch and run the the main app
            var app = new App(filepath, punctuationHandle, interogation, reader, filterFactory);
            app.Run();
        }
         
    }
}
