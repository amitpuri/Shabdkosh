using Shabdkosh.Persistence;
using Shabdkosh.TextOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shabdkosh.Services
{
    public interface IShabdkoshService
    {
        Shabd SearchAWord(string keyword);
        IEnumerable<Shabd> TopWords(int top);
    }

    public class ShabdkoshService : IShabdkoshService
    {
        private readonly Dictionary<string, int> occuranceOfAWord;
        private readonly ITextOperation _textOperation;

        public ShabdkoshService(ITextFileRepository fileRepository, ITextOperation textOperation)
        {
            _textOperation = textOperation;
            string text = fileRepository.ReadTextFile();
            occuranceOfAWord = _textOperation.Text2DictWordOccurance(text);
        }

        public IEnumerable<Shabd> TopWords(int top)
        {
            return from word in occuranceOfAWord.AsParallel().OrderByDescending(kp => kp.Value)
                                                  .Select(kp => kp.Key)
                                                  .ToList().Take(top)
                   select new Shabd
                   {
                       Word = word,
                       Occurance = occuranceOfAWord[word],
                       Definition = _textOperation.GetDefinition(word)
                   };
        }

        public Shabd SearchAWord(string keyword)
        {
            return new Shabd
            {
                Word = keyword,
                Occurance = occuranceOfAWord[keyword],
                Definition = _textOperation.GetDefinition(keyword)
            };
        }

    }
}
