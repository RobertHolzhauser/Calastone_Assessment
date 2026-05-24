using System;
using System.Collections.Generic;
using System.Text;
using Calastone_TextFilter.Models;

namespace Calastone_TextFilter.Interfaces
{
    internal interface IinterogationService
    {
        InterogatedWord Interogate(string word);
    }
}
