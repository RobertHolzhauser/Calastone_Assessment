using System;
using System.Collections.Generic;
using System.Text;
using TextFilter.Interfaces;

namespace TextFilter.Factories
{
    public class FilterFactory : IFilterFactory
    {
        private readonly Func<IEnumerable<ITextFilter>> _factory;
        
        // constructor
        public FilterFactory(Func<IEnumerable<ITextFilter>> factory)   // parameter gives all the instances of ITextFilter in DI
        { 
            _factory = factory;
        }

        // Create method - returns the filter that matches the filtername that was passed in (aka requested)
        public ITextFilter Create(string filterName) 
        {
            var set = _factory();
            ITextFilter filter = set.Where(x => x.FilterName.ToLower() == filterName.ToLower()).First();
            return filter;
        }
    }
}
