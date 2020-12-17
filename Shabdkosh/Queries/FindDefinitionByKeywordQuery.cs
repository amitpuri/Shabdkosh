using MediatR;
using Shabdkosh.Models;

namespace Shabdkosh.Queries
{
    public class FindDefinitionByKeywordQuery : IRequest<Shabd>
    {
        public string Keyword { get; set; }
    }
}
