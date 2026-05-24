using TextFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilter.Filters
{
    public class Filter3: ITextFilter
    {
        /***
         *  Filter3 filters out words that contain the letter t
         **/ 
        public string Filter(string text)
        {
            if (text.Contains('t')) return "";
            
            return text;
        }
    }
}
