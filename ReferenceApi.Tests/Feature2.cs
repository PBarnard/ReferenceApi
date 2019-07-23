using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Gherkin.Ast;
using Newtonsoft.Json;
using ReferenceApi.Models;
using Xunit;
using Xunit.Gherkin.Quick;
using Feature = Xunit.Gherkin.Quick.Feature;

namespace ReferenceApi.Tests
{
    public class Feature2 : Feature
    {
        const string BaseApiUrl = "https://localhost:44396/";

        private readonly HttpClient _client;
        private HttpResponseMessage _response;

        public Feature2()
        {
            this._client = new HttpClient();
        }

        [Given("the API is available")]
        public async Task TheApiIsAvailable()
        {
            Assert.True(await this.CheckApiHealth());
        }

        [When("I perform a request to the Species endpoint")]
        public async Task PerformRequestToSpeciesEndpoint()
        {
            var result = await this._client.GetAsync($"{BaseApiUrl}Reference/species");

            this._response = result;
        }

        [When("I perform a request to the Species endpoint with the identifier '(.+)'")]
        public async Task PerformRequestToSpeciesEndpointWithIdentifier(string identifier)
        {
            var result = await this._client.GetAsync($"{BaseApiUrl}Reference/species/{identifier}");

            this._response = result;
        }

        [When(@"I request data from the Species endpoint the outcomes are as expected according to the table")]
        public async Task RequestSpeciesDataFromTheApiUsingTable(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows.Skip(1))
            {
                var identifier = row.Cells.ElementAt(0).Value;

                await this.PerformRequestToSpeciesEndpointWithIdentifier(row.Cells.ElementAt(0).Value);
                this.ApiReturnsStatusCode(int.Parse(row.Cells.ElementAt(1).Value));
            }
        }

        [Then(@"the API returns a '(\d+)' status code")]
        public void ApiReturnsStatusCode(int statusCode)
        {
            Assert.True(this._response.StatusCode == (HttpStatusCode) statusCode);
        }

        [And("a collection of 'Species' instances is retrieved")]
        public async Task CollectionOfSpeciesInstancesRetrieved()
        {
            var content = await this._response.Content.ReadAsStringAsync();

            var data = (JsonConvert.DeserializeObject<IEnumerable<Species>>(content)).ToList();

            Assert.True(data.Count == 3);
            Assert.True(data.All(item => item.GetType().FullName == typeof(Species).FullName));
        }

        [And("a 'Species' instances is retrieved")]
        public async Task SpeciesInstanceRetrieved()
        {
            var content = await this._response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Species>(content);

            Assert.NotNull(data);
            Assert.True(data.GetType().FullName == typeof(Species).FullName);
        }

        private async Task<bool> CheckApiHealth()
        {
            var result = await this._client.GetAsync(new Uri(BaseApiUrl + "health/live"));

            return result.StatusCode == HttpStatusCode.OK;
        }
    }
}
