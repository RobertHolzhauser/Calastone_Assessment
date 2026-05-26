using TextFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Models;

namespace TextFilter.Filters
{
    public class Filter3: ITextFilter
    {
        public string FilterName { get; set; } = "Filter3";

        /***
         *  Filter3 filters out words that contain the letter t
         **/
        public InterrogatedWord Filter(InterrogatedWord word)
        {
            if (word.OriginalWord.Contains('t')) 
                word.CleanedWord = "";
            
            return word;
        }
    }
}
