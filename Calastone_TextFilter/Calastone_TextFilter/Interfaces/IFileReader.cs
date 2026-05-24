using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilter.Interfaces
{
    public interface IFileReader
    {
        string Read(string path);
    }
}
