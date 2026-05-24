using System.Collections;
using Calastone_TextFilter.Interfaces;
using Calastone_TextFilter.Main;
using Calastone_TextFilter.Services;
using Calastone_TextFilter.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Calastone_TextFilter
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


            var app = new App(filepath, keepPunctuation);
            app.Run();
            /*
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new(filepath);

                // Read the stream as a string.
                string text = reader.ReadToEnd();

                // clean any leading or trailing whitespace
                text = text.Trim();

                var txtArray = text.Split(' ');

                foreach (var txt in txtArray)
                {
                    Console.WriteLine(txt);  // TODO remove

                    InterogatedWord interogatedWord = Interogate(txt);  // TODO  move this to app
                    interogatedWord.OriginalWord = txt;




                }


                // Write the text to the console.
                Console.WriteLine(text);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            */
        }

       
    }
}
