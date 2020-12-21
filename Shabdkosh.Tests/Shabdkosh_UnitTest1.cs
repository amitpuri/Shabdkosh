using Shabdkosh.Persistence;
using Shabdkosh.Services;
using Shabdkosh.Queries;
using Shabdkosh.TextOperations;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace ShabdKosh.Tests
{
    public class Shabdkosh_UnitTest1
    {
        private readonly ITextFileRepository fileRepository;
        private readonly ITextOperation textOperation;
        private readonly IShabdkoshService shabdkoshService;
        public Shabdkosh_UnitTest1()
        {
            //arrange
            fileRepository = new TextFileRepository();
            textOperation = new TextOperation();
            shabdkoshService = new ShabdkoshService(fileRepository, textOperation);
        }

        [Fact(DisplayName = "Search a Word")]
        [Trait("Category", "unit")]
        public void Test1_SearchAWord()
        {
            //Arrange
            string keyword = "university";
            //act
            var result = shabdkoshService.SearchAWord(keyword);
            //assert
            Assert.True(!string.IsNullOrEmpty(result.Definition));
        }

        [Fact(DisplayName = "Search a word - not found")]
        [Trait("Category", "unit")]

        public void Test2_SearchAWord_NotFound()
        {
            //Arrange
            string keyword = "hiawatha";
            //act
            var result = shabdkoshService.SearchAWord(keyword);
            //assert

            Assert.True(result.Definition == "[{\"message\":\"No definition :(\"}]");
        }

        [Fact(DisplayName = "Top 5 words")]
        [Trait("Category", "unit")]
        public void Test3_Get_Top5Words()
        {
            //arrange
            var topN = 5;
            //act
            var words = shabdkoshService.TopWords(topN);
            //assert
            Assert.True(words.Count() == topN);
        }

        [Fact(DisplayName = "Search a word - invalid word")]
        [Trait("Category", "unit")]
        public void Test4_SearchAInvalidWord()
        {
            //Arrange
            string keyword = "test";
            //act
            try
            {
                shabdkoshService.SearchAWord(keyword);
                //assert
                Assert.True(false);
            }
            catch (KeyNotFoundException)
            {
                //assert
                Assert.True(true);
            }
        }

        [Fact(DisplayName = "Find Definition By Keyword - returns word")]
        [Trait("Category", "unit")]
        public async Task FindDefinitionByKeywordQuery_ReturnsKeywordDefinition()
        {
            //Arrange
            var findDefinitionByKeywordHandler = new FindDefinitionByKeywordHandler(fileRepository, textOperation);
            string keyword = "university";
            //act
            var result = await findDefinitionByKeywordHandler.Handle(new FindDefinitionByKeywordQuery { Keyword = keyword}, new CancellationToken());
            //assert
            Assert.NotNull(result);            
        }

        [Fact(DisplayName = "Find Definition By Keyword - invalid word")]
        [Trait("Category", "unit")]
        public async Task FindDefinitionByKeywordQuery_InvalidWord()
        {
            var findDefinitionByKeywordHandler = new FindDefinitionByKeywordHandler(fileRepository, textOperation);
            string keyword = "test";

            try
            {
                var result = await findDefinitionByKeywordHandler.Handle(new FindDefinitionByKeywordQuery { Keyword = keyword}, new CancellationToken());
                //assert
                Assert.True(false);
            }
            catch (KeyNotFoundException)
            {
                //assert
                Assert.True(true);
            }
        }
    }
}