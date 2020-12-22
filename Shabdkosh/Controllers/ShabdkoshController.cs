using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using System.Threading.Tasks;
using Shabdkosh.Queries;

namespace Shabdkosh.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShabdkoshController : ControllerBase
    {

        private readonly IMediator mediator;
        
        public ShabdkoshController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /* 
        private readonly ShabdkoshService _shabdkoshService;
        
        public ShabdkoshController(ITextFileRepository fileRepository, ITextOperation textOperation)
        {
            this._shabdkoshService = new ShabdkoshService(fileRepository, textOperation) ?? throw new ArgumentNullException(nameof(ShabdkoshService));
        } 
        
        [Route("/{top}")]
        [HttpGet]
        public IEnumerable<Shabd> TopWords(int top)
        {
            return _shabdkoshService.TopWords(top);
        }

        [HttpPost]
        public Shabd SearchAWord(string keyword)
        {
            return _shabdkoshService.SearchAWord(keyword.ToLower());
        }
        */

        [Route("/{keyword}")]
        [HttpGet]
        public async Task<ActionResult> GetByKeyword([FromRoute]string keyword)
        {
            var result = await mediator.Send(new FindDefinitionByKeywordQuery{ Keyword = keyword });                        
            return new JsonResult(result);
        }

    }
}
