using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilter.Models
{
    /***
     * Interrogated word implies a word that HAS NOT YET been filtered, 
     *   but has had any non-letters removed, for the sake of filtering.
     *   while allowing the original word to be reconstructed with these characters post filtering.
     *   Design note:  Any non letter chars could be contained in midChars, however, for simplicity I'm seperating out non word
     *          characters into 3 categories of pre, post, and mid.  Pre and Post can be applied wholesale without regard to position.
     *          Any midword characters will have to be reconstructed with regard to any position alterations potentially applied by filters.
     **/ 
    public class InterrogatedWord
    {
        public string OriginalWord = string.Empty;  // this is the original non-modified word 
        public string CleanedWord = string.Empty;  // this is the word after filtering.  Which may continue to be empty if a filter removes it. 
        public string preFix = string.Empty;       // this will be used to re-apply post filtering any leading non-text chars
        public string postFix = string.Empty;      // this will be used to re-apply post filtering any trailing non-text chars (punctuation, etc.)
        public List<MidChars> midChars;           // this has any non AZaz chars in the middle of the word, and the position

        // Original Word Constructor
        public InterrogatedWord(string originalWord) 
        {
            OriginalWord = originalWord;
            midChars = new List<MidChars>();  
        }

        // default constructor
        public InterrogatedWord()
        {
            midChars = new List<MidChars>();
        }
    }
}
