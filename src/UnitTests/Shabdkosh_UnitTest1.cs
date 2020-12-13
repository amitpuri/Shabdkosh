using Newtonsoft.Json;
using Shabdkosh;
using Shabdkosh.Persistence;
using Shabdkosh.Services;
using Shabdkosh.TextOperations;
using System;
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
            string keyword = "University";
            //act
            var result = shabdkoshService.SearchAWord(keyword);

            //assert
            Assert.True(!string.IsNullOrEmpty(result.Definition));
        }


        [Fact]
        public void Test2_Get_Top5Words()
        {
            //arrange
            var topN = 5;
            //act
            var words = shabdkoshService.TopWords(topN);
            
            //assert
            Assert.True(words.Count()== topN);
        }               
    }
}
