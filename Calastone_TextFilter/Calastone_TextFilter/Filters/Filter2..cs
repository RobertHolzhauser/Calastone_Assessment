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
        public int sequence { get; set; } = 1;

        /***
         * Filter2 filters out words with a length less than 3.
         **/
        public InterrogatedWord Filter(InterrogatedWord word)
        {
            if (word.CleanedWord.Length < 3) 
                word.CleanedWord = "";

            Console.WriteLine("Filter2" + word.CleanedWord);
            return word;
        }
    }
}
