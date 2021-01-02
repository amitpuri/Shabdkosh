using Microsoft.AspNetCore.Mvc;
using System;
using Shabdkosh.Services;
using Shabdkosh.TextOperations;
using Shabdkosh.Persistence;
using Shabdkosh.Models;
using System.Collections.Generic;

namespace Shabdkosh.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [ControllerName("Shabdkosh")]
    [Route("[controller]")]
    public class ShabdkoshController : ControllerBase
    {
               
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

    }

}
