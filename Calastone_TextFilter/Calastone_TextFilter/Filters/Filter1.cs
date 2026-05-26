using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TextFilter.Interfaces;
using TextFilter.Models;

namespace TextFilter.Filters
{
    public class Filter1: ITextFilter
    {

        string[] Vowels = { "A", "a", "E", "e", "I", "i", "O", "o", "U", "u" };
        public string FilterName { get; set; } = "Filter1";
        /***
         * Filter1 filters out words that contain a vowel in the middle1 or 2 characters of the word
         **/
        public InterrogatedWord Filter(InterrogatedWord word)
        {
            if (word == null) return new InterrogatedWord();            
            int pos = FindMiddlePosition(word.OriginalWord);
            string parity = CheckOddEven(pos);      // even means we check the middle two characters
            string middleChars = FindMiddleChars(word.OriginalWord, parity, pos);

            foreach (char ch in middleChars) 
            {
                if (Vowels.Contains(ch.ToString())) 
                { 
                    middleChars = "";
                    break;
                }
            }
            int afterMidPos = pos + middleChars.Length + 1;
            word.CleanedWord = word.OriginalWord.Substring(0, pos).Concat(middleChars)
                    .Concat(word.OriginalWord.Substring(afterMidPos, word.OriginalWord.Length -1)).ToString()!;
            return word;
        }

        int FindMiddlePosition(string text)
        {
            if (text.Length <= 2) return -1;
            
            return text.Length / 2;   
        }

        string CheckOddEven(int Len)
        {
            switch (Len % 2)
            {
                case 0 : 
                    return "Even";
                    break; 
                default:
                   return "Odd";
            }
        }
            
        string FindMiddleChars(string text, string OorE, int middle) 
        {
            if (OorE == "Odd")
            {
                return text.ElementAt(middle).ToString();
            }
            else
            {
                return text.ElementAt(middle).ToString() + text.ElementAt(middle + 1).ToString();
            }              
        }
       
    }
}
