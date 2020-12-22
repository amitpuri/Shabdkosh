using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shabdkosh.Models;
using Shabdkosh.Persistence;
using Shabdkosh.TextOperations;

namespace Shabdkosh.Queries
{
    public class FindDefinitionByKeywordHandler : IRequestHandler<FindDefinitionByKeywordQuery, Shabd>
    {
        private readonly ITextFileRepository fileRepository;
        private readonly ITextOperation _textOperation;

        public FindDefinitionByKeywordHandler(ITextFileRepository fileRepository, ITextOperation textOperation)
        {
            this.fileRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            this._textOperation = textOperation ?? throw new ArgumentNullException(nameof(textOperation));

        } 

        public async Task<Shabd> Handle(FindDefinitionByKeywordQuery request, CancellationToken cancellationToken)
        {
            var word = request.Keyword.ToLower();
            var result = fileRepository.ReadTextFile();
            var occuranceOfAWord = _textOperation.Text2DictWordOccurance(result);

            return result != null ? new Shabd
            {
                Word = word,
                Occurance = occuranceOfAWord[word],
                Definition =await _textOperation.GetDefinitionAsync(word)
            } : null;
        }
    }
}