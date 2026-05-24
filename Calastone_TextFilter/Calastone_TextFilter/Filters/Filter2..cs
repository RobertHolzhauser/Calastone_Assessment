using Calastone_TextFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calastone_TextFilter.Filters
{
    public class Filter2: ITextFilter
    {
        /***
         * Filter2 filters out words with a length less than 3.
         **/ 
        public string Filter(string text)
        {
            if (text.Length < 3) return "";
            
            return text;
        }
    }
}
