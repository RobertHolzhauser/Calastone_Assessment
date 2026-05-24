using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Models;

namespace TextFilter.Interfaces
{
    public interface IinterogationService
    {
        InterogatedWord Interogate(string word);
    }
}
