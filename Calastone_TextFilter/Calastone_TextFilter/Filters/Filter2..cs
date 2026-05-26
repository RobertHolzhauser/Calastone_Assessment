using TextFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Models;

namespace TextFilter.Filters
{
    public class Filter2: ITextFilter
    {

        public string FilterName { get; set; } = "Filter2";
        /***
         * Filter2 filters out words with a length less than 3.
         **/
        public InterrogatedWord Filter(InterrogatedWord word)
        {
            if (word.OriginalWord.Length < 3) word.CleanedWord = "";
            
            return word;
        }
    }
}
