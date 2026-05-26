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
        public int sequence { get; set; } = 2;

        /***
         *  Filter3 filters out words that contain the letter t
         **/
        public InterrogatedWord Filter(InterrogatedWord word)
        {
            if (word.OriginalWord.Contains("t"))  // this will leave words with capital T  -- to remove them add toLower() as in: word.OriginalWord.toLower().Contains("t")
            {
                word.CleanedWord = "";
            }
            else
            {
                word.CleanedWord = word.OriginalWord;
            }

            Console.WriteLine("Completed Filter 3");
            return word;
        }
    }
}
