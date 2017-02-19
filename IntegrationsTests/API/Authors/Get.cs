using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MVCDemos;
using MVCDemos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace IntegrationsTests.API.Authors
{
    public class Get : BaseApiTest
    {
        [Fact]
        public async void ReturnsListOfAuthors()
        {
            var client = GetClient();

            var response = await client.GetAsync("/api/authors");

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Author>>(stringResponse).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal(1, result.Count(a => a.FullName == "Steve Smith"));
        }
    }
}
