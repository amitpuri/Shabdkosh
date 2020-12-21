using Microsoft.AspNetCore.Mvc.Testing;
using Shabdkosh;
using Shabdkosh.Models;
using Xunit;
using System.Threading.Tasks;
using System.Net.Http;

namespace ShabdKosh.Tests
{
    public class ShabdkoshController_UnitTest2 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

         public ShabdkoshController_UnitTest2(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact(DisplayName = "Search a word and get definition")]
        [Trait("Category", "unit")]        
        public async Task GetByKeyword_ReturnsDefinition()
        {
            string keyword = "university";
            string url = string.Format("/{0}", keyword);
            
            var client = factory.CreateClient();
            
            var response = await client.DoGetAsync<Shabd>(url);

            Assert.Equal(response.Word,keyword);
        }

        [Fact(DisplayName = "Search a word - not found")]
        [Trait("Category", "unit")]        
        public async Task GetByKeyword_InvalidKeyword()
        {
            string keyword = "test";
            string url = string.Format("/{0}", keyword);
            
            var client = factory.CreateClient();
            try
            {
                var response = await client.DoGetAsync<Shabd>(url);
                Assert.True(false);
            }
            catch (HttpRequestException)
            {
                Assert.True(true);
            }
        }
    }
}
