using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using System.Threading.Tasks;
using Shabdkosh.Queries;

namespace Shabdkosh.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [ControllerName("Shabdkosh")]
    [Route("[controller]")]
    public class Shabdkosh2Controller : ControllerBase
    {

        private readonly IMediator mediator;

        public Shabdkosh2Controller(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("/{keyword}")]
        [HttpGet]
        public async Task<ActionResult> GetByKeyword([FromRoute] string keyword)
        {
            var result = await mediator.Send(new FindDefinitionByKeywordQuery { Keyword = keyword });
            return new JsonResult(result);
        }

    }
}
