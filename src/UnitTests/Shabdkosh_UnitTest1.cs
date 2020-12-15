using Shabdkosh.Persistence;
using Shabdkosh.Services;
using Shabdkosh.TextOperations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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

        [Fact]
        public void Test1_SearchAWord()
        {
            //Arrange
            string keyword = "university";
            //act
            var result = shabdkoshService.SearchAWord(keyword);
            //assert
            Assert.True(!string.IsNullOrEmpty(result.Definition));
        }

         [Fact]
        public void Test2_SearchAWord_NoTFound()
        {
            //Arrange
            string keyword = "hiawatha";
            //act
            var result = shabdkoshService.SearchAWord(keyword);
            //assert
            
            Assert.True(result.Definition=="[{\"message\":\"No definition :(\"}]");
        }

        [Fact]
        public void Test3_Get_Top5Words()
        {
            //arrange
            var topN = 5;
            //act
            var words = shabdkoshService.TopWords(topN);
            //assert
            Assert.True(words.Count()== topN);
        }               


        [Fact]
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
    }
}
