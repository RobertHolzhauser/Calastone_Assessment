using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Calastone_TextFilter.Interfaces;

namespace Calastone_TextFilter.Services
{
    internal class FileReader : IFileReader
    {
        public string Read(string filepath) 
        {
            // Open the text file using a stream reader.
            using StreamReader reader = new StreamReader(filepath);

            // Read the stream as a string.
            return reader.ReadToEnd();
        }
        
    }
}
