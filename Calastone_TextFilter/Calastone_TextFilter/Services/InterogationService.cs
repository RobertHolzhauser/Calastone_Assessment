using Calastone_TextFilter.Interfaces;
using Calastone_TextFilter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calastone_TextFilter.Services
{
    internal class InterogationService : IinterogationService
    {
       
         /***
         * Check If there are pre or post non letter characters.
         * If so, remove them from the word, and capture them as pre or post
         * Then, if there are non AZaz characters in the middle of the word capture them along with the position
         **/
        public InterogatedWord Interogate(string word)
        {
            InterogatedWord intWord = new InterogatedWord();
            intWord.OriginalWord = word;

            StringBuilder preStringBuilder = new StringBuilder();
            StringBuilder postStringBuilder = new StringBuilder();
            //StringBuilder newWordStringBuilder = new StringBuilder();  TODO remove


            int len = word.Length;   // placed in a variable outside of for loop to avoid re-calc with every iteration

            Regex regex = new Regex(@"[^A-Za-z]");

            // Get any prefix
            for (int i = 0; i <= len; i++)
            {
                Match match = regex.Match(word[i].ToString());
                if (match.Success)  // If not a letter
                {
                    preStringBuilder.Append(word[i].ToString());
                }
                else    // valid letter 
                {
                    break;
                }
            }
            if (preStringBuilder.Length > 0)
            {
                intWord.preFix = preStringBuilder.ToString();
            }

            // Get any postfix, starting at the end of the word and moving left
            for (int i = len; i >= 0; i--)
            {
                Match matchPost = regex.Match(word[i].ToString());
                if (matchPost.Success)  // If not a letter  
                {
                    preStringBuilder.Append(word[i].ToString());
                }
                else    // valid letter 
                {
                    break;
                }
            }
            if (postStringBuilder.Length > 0)
            {
                intWord.postFix = postStringBuilder.ToString();
            }

            int preLen = preStringBuilder.Length > 0 ? preStringBuilder.Length - 1 : 0;  // adjust for zero based index
            string midWord = word.Substring(preLen, len - postStringBuilder.Length);

            Match matchMid = regex.Match(midWord);
            if (matchMid.Success)
            {
                int midLen = midWord.Length;
                List<MidChars> midChars = new List<MidChars>();
                for (int i = 0; i <= midLen; i++)
                {
                    Match midCharMatch = regex.Match(midWord[i].ToString());
                    if (midCharMatch.Success)
                    {
                        MidChars mids = new MidChars(midWord[i], i);
                        midChars.Add(mids);

                    }
                    intWord.midChars = midChars;
                }
            }

            // Build the cleaned word
            string CleanedWord = word.Substring(preLen, len - postStringBuilder.Length);

            // if any midChars loop through the cleaned word and remove chars at position 

            return intWord;

        }
    }
}
