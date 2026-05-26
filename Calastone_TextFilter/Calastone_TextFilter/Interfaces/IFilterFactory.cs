using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilter.Interfaces
{
    public interface IFilterFactory
    {
        ITextFilter Create(int sequence);
    }
}
