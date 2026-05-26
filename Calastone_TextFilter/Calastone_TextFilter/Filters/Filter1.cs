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
        public int sequence { get; set; } = 3;

        /***
         * Filter1 filters out words that contain a vowel in the middle1 or 2 characters of the word
         **/
        public InterrogatedWord Filter(InterrogatedWord word)
        {
            if (word == null) return new InterrogatedWord();
            try
            {             
                int myLen = word.CleanedWord.Length;
                if (myLen > 0)
                {
                    int pos = FindMiddlePosition(word.OriginalWord);
                    Console.WriteLine("filter 1 - originalWord = " + word.OriginalWord + "  - pos = " + pos + " myLen = " + myLen);
                    string parity = CheckOddEven(myLen);
                    Console.WriteLine("filter 1 - parity = " + parity);
                    string middleChars = "";


                    if (myLen > 2)
                    {
                        middleChars = FindMiddleChars(word.OriginalWord, parity, pos);
                        Console.WriteLine("filter 1 - middleChars = " + middleChars);
                        foreach (char ch in middleChars)
                        {
                            if (Vowels.Contains(ch.ToString()))
                            {
                                //middleChars = "";
                                word.CleanedWord = "";
                                Console.WriteLine("Removed word: " + word.OriginalWord);
                                return word;
                            }
                        }
                    }

                    Console.WriteLine("Cleaned Word = " + word.CleanedWord);
                }
            } catch (Exception ex) 
            { 
                Console.WriteLine("ERROR on word " + word.OriginalWord + " = " + ex.Message); 
            }
            return word;
        }

        int FindMiddlePosition(string text)
        {
            if (text.Length <= 2) return 1;
            
            return text.Length / 2;   
        }

        string CheckOddEven(int Len)
        {
            switch (Len % 2)
            {
                case 0 : 
                    return "Even";
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
                return text.ElementAt(middle -1).ToString() + text.ElementAt(middle).ToString();
            }              
        }
       
    }
}
