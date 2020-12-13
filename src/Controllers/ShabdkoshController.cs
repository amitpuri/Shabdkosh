using Microsoft.AspNetCore.Mvc;
using Shabdkosh.Persistence;
using Shabdkosh.Services;
using Shabdkosh.TextOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Shabdkosh.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShabdkoshController : ControllerBase
    {

        private readonly ShabdkoshService _shabdkoshService;

        public ShabdkoshController(ITextFileRepository fileRepository, ITextOperation textOperation)
        {
            _shabdkoshService = new ShabdkoshService(fileRepository, textOperation);
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
            return _shabdkoshService.SearchAWord(keyword);
        }

    }
}
