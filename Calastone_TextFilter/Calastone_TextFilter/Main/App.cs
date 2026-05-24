using System.Text;
using System.Text.RegularExpressions;
using TextFilter.Models;
using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Services;

namespace TextFilter.Main
{
    public class App
    {
        private readonly string _filePath;
        private readonly bool _keepPunctuation;
        private readonly IinterogationService _interogationService;
        private readonly IFileReader _reader;

        // constructor
        public App(string filepath, bool keepPunctuation, IinterogationService interogation, IFileReader reader)
        {
            _filePath = filepath;
            _keepPunctuation = keepPunctuation;
            _interogationService = interogation;
            _reader = reader;
        }
        
        public void Run() 
        {
            try
            {
                // Read the stream as a string.
                string text = _reader.Read(_filePath);

                // clean any leading or trailing whitespace
                text = text.Trim();

                var txtArray = text.Split(' ');

                foreach (var txt in txtArray)
                {
                    Console.WriteLine(txt);  // TODO remove

                    InterogatedWord interogatedWord = _interogationService.Interogate(txt); 
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

        }
    }
}
