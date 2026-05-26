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
        private readonly string _punctuationHandle;
        private readonly IinterogationService _interogationService;
        private readonly IFileReader _reader;
        private readonly IFilterFactory _filterFactory;
        private readonly ITextFilter _filter1;
        private readonly ITextFilter _filter2;
        private readonly ITextFilter _filter3;

        // constructor
        public App(string filepath, string punctuationHandle, IinterogationService interogation, IFileReader reader, IFilterFactory FilterFactory )
        {
            _filePath = filepath;
            _punctuationHandle = punctuationHandle;
            _interogationService = interogation;
            _reader = reader;
            _filterFactory = FilterFactory;
            _filter1 = _filterFactory.Create("Filter1");
            _filter2 = _filterFactory.Create("Filter2");
            _filter3 = _filterFactory.Create("Filter3");
            Console.WriteLine("Finished App instantiation.");
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

                StringBuilder finalTextBuilder = new StringBuilder();  // string builder is more efficient than 
                
                foreach (var txt in txtArray)
                {
                    Console.WriteLine(txt);  // TODO remove

                    InterrogatedWord interogatedWord = new InterrogatedWord(txt);
                    if (_punctuationHandle == "interogate") 
                    { 
                        interogatedWord = _interogationService.Interogate(txt);   // TODO add other handlings as implementation of IinterogationService
                    }

                    var interogatedWord_phase1 = _filter1.Filter(interogatedWord);
                    var interogatedWord_phase2 = _filter2.Filter(interogatedWord_phase1);
                    var interogatedWord_phase3 = _filter3.Filter(interogatedWord_phase2);
                    finalTextBuilder.Append(interogatedWord_phase3.CleanedWord);
                }

                string finalText = finalTextBuilder.ToString();

                // Write the text to the console.
                Console.WriteLine(finalText);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
    }
}
