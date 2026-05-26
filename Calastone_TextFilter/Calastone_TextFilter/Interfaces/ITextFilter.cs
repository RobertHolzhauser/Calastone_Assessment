using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Models;

namespace TextFilter.Interfaces
{
    public interface ITextFilter
    {
        InterrogatedWord Filter(InterrogatedWord word);
        string FilterName { get; set; }
    }
}
