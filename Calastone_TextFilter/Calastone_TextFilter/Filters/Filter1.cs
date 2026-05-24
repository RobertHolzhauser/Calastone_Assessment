using Calastone_TextFilter.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Calastone_TextFilter.Filters
{
    public class Filter1: ITextFilter
    {

        string[] Vowels = { "A", "a", "E", "e", "I", "i", "O", "o", "U", "u" };
        /***
         * Filter1 filters out words that contain a vowel in the middle1 or 2 characters of the word
         **/
        public string Filter(string text)
        {
            if (text == null) return "";            
            int pos = FindMiddlePosition(text);
            string parity = CheckOddEven(pos);      // even means we check the middle two characters
            string middleChars = FindMiddleChars(text, parity, pos);

            foreach (char ch in middleChars) 
            {
                if (Vowels.Contains(ch.ToString())) 
                { 
                    middleChars = "";
                    break;
                }
            }
            int afterMidPos = pos + middleChars.Length + 1;
            return text.Substring(0, pos).Concat(middleChars).Concat(text.Substring(afterMidPos, text.Length -1)).ToString();
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
