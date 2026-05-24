using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TextFilter.Models
{
    public class MidChars
    {
        
        public char midChar;
        public int midCharPosition = 0;

        public MidChars(char aMidChar, int pos) 
        { 
            midCharPosition = pos;
            midChar = aMidChar;
        }
    }
}
