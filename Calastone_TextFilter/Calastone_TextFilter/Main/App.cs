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
        private readonly ITextFilter _filterSeq1;
        private readonly ITextFilter _filterSeq2;
        private readonly ITextFilter _filterSeq3;

        // constructor
        public App(string filepath, string punctuationHandle, IinterogationService interogation, IFileReader reader, IFilterFactory FilterFactory )
        {
            _filePath = filepath;
            _punctuationHandle = punctuationHandle;
            _interogationService = interogation;
            _reader = reader;
            _filterFactory = FilterFactory;
           
            _filterSeq1 = _filterFactory.Create(1);  // optimized sequence = filter 3 runs first  
            _filterSeq2 = _filterFactory.Create(2);  //  filter 2 runs second 
            _filterSeq3 = _filterFactory.Create(3);  //  filter 1 runs last to avoid running more complex logic when not necessary

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
                    if (_punctuationHandle == "interrogate") 
                    { 
                        interogatedWord = _interogationService.Interogate(txt);   // TODO add other handlings as implementation of IinterogationService
                    }

                    interogatedWord = _filterSeq1.Filter(interogatedWord);

                    if (interogatedWord.CleanedWord.Length > 0)  // Only run if not filtered out already
                    {
                        interogatedWord = _filterSeq2.Filter(interogatedWord);
                    }
                    else
                    {
                        continue;
                    }

                    interogatedWord = _filterSeq3.Filter(interogatedWord);
                    if (interogatedWord.CleanedWord.Length > 0)
                    {

                        finalTextBuilder.Append(interogatedWord.CleanedWord).Append(" ");
                        
                    }                  
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
