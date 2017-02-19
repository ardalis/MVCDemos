using MVCDemos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationsTests.API.Authors
{
    public class Put : BaseApiTest
    {
        [Fact]
        public async Task ReturnsNotFoundForId0()
        {
            var client = GetClient();

            var authorToPost = new Author() { Id = 0, FullName = "test", TwitterAlias = "testalias" };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(authorToPost),
                Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/authors/0", jsonContent);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.Equal("0", stringResponse);
        }
    }
}
