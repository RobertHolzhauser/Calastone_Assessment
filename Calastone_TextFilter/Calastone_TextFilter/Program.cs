using System.Collections;

namespace Calastone_TextFilter
{
    internal class Program
    {
        /***
         * TextFiler App
         * Assume that we get the path to the input file from args(0) 
         **/ 
        static void Main(string[] args)
        {
            if (args.Length == 0) { throw new ArgumentNullException("File Path is missing"); }
            Console.WriteLine($"The input file path is {args[0]}");

            string filepath = args[0];

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
                    Console.WriteLine(txt);
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
