using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Security.Cryptography.X509Certificates;
using TextFilter.Extensions;
using TextFilter.Factories;
using TextFilter.Factories;
using TextFilter.Filters;
using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Interfaces;
using TextFilter.Models;
using TextFilter.Services;


namespace TextFilter.Tests
{
    

    public class FilterTests
    {
        private readonly IFilterFactory _filterFactory;


        public FilterTests()
        { 
            var services = new ServiceCollection().AddTextFilterServices();
            _filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();
        }

        [Fact]
        public void Test1()  // smoke test
        {
            Assert.True(true);
        }

        [Fact]
        public void Filter3_Factory_Create_ReturnsFilter3()
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();

            // Act
            var filter3 = filterFactory.Create(2);  
              
            // Assert
            Assert.IsType<Filter3>(filter3);
        }

        [Fact]
        public void Filter2_Factory_Create_ReturnsFilter2()
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();

            // Act
            var filter2 = filterFactory.Create(1);

            // Assert
            Assert.IsType<Filter2>(filter2);
        }

        [Fact]
        public void Filter1_Factory_Create_ReturnsFilter1()
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();

            // Act
            var filter1= filterFactory.Create(3);

            // Assert
            Assert.IsType<Filter1>(filter1);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("is")]
        [InlineData("An")]
        [InlineData("a")]
        public void Filter2_RemovesOneAndTwoCharWords(string txt)
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();
            var filter3 = filterFactory.Create(1);
            InterrogatedWord word = new InterrogatedWord(txt);


            // Act
            var Tested = filter3.Filter(word);


            // Assert
            Assert.Equal(word.CleanedWord,"");
        }

        [Theory]
        [InlineData("Robert")]
        [InlineData("The")]
        [InlineData("idea")]
        [InlineData("paragraph")]
        public void Filter2_DoesNotRemove3orMoreCharWords(string txt)
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();
            var filter3 = filterFactory.Create(1);
            InterrogatedWord word = new InterrogatedWord(txt);

            // Act
            var Tested = filter3.Filter(word);

            // Assert
            Assert.Equal(word.CleanedWord,txt);
        }

        [Theory]
        [InlineData("Robert")]
        [InlineData("The")]
        [InlineData("integer")]
        [InlineData("talent")]
        [InlineData("smart")]
        public void Filter3_RemoveWordsWithT(string txt)
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();
            var filter3 = filterFactory.Create(1);
            InterrogatedWord word = new InterrogatedWord(txt);

            // Act
            var Tested = filter3.Filter(word);

            // Assert
            Assert.Equal(word.CleanedWord,"");
        }

        [Theory]
        [InlineData("Holzhauser")]
        [InlineData("live")]
        [InlineData("genius")]
        [InlineData("coffee")]
        [InlineData("lion")]
        public void Filter3_KeepWordsWithoutT(string txt)
        {
            // Arrange 
            var services = new ServiceCollection().AddTextFilterServices();
            var filterFactory = services.BuildServiceProvider().GetRequiredService<IFilterFactory>();
            var filter3 = filterFactory.Create(1);
            InterrogatedWord word = new InterrogatedWord(txt);

            // Act
            var Tested = filter3.Filter(word);

            // Assert
            Assert.Equal(word.CleanedWord,txt);
        }




    }
}
