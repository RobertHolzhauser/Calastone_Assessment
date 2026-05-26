using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Security.Cryptography.X509Certificates;
using TextFilter.Factories;
using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Models;
using TextFilter.Services;
using TextFilter.Interfaces;
using TextFilter.Factories;
using TextFilter.Filters;


namespace TextFilter.Tests
{
    

    public class FilterTests
    {
        private readonly IFilterFactory _filterFactory;
        private readonly ITextFilter _filterSeq1;

        public FilterTests(IFilterFactory filterFactory, ITextFilter filterSeq1)
        {
            _filterFactory = filterFactory;
            _filterSeq1 = filterSeq1;
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Filter3_Contains_t()
        {
            // Arrange 
            InterrogatedWord word = new InterrogatedWord();
            word.OriginalWord = "tank";

            var filter3 = _filterFactory.Create(1);  // optimized sequence = filter 3 runs first  
            var testedWord = filter3.Filter(word);
  

            Assert.Equal(testedWord.CleanedWord, "");
        }

    }
}
