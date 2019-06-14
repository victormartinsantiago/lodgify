namespace VacationRental.Contact.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    [Collection("Integration")]
    public class UpdateContactTests
    {
        private readonly HttpClient _client;
        private readonly Random _rnd;

        public UpdateContactTests(IntegrationFixture fixture)
        {
            _client = fixture.Client;
            _rnd = fixture.Random;
        }

        [Fact]
        public async Task GivenCompleteRequest_WhenUpdateContact_ThenAGetReturnsTheUpdatedContact()
        {
            var vacationRentalId = _rnd.Next();
            var request = new
            {
                Forename = "Flash",
                Surname = "Gordan",
                Phone = "1800-SPEED-ING",
                NativeLanguage = "English",
                OtherSpokenLanguages = new[] { "Spanish" },
                ////AboutMe = new[] { new { Language = "Spanish", Text = "Whatever" } },
                AboutMe = new Dictionary<string, string>
                {
                    { "Spanish", "Whatever" }
                }
            };

            using (var updateResponse = await _client.PutAsJsonAsync($"/api/v1/vacationrental/{vacationRentalId}/contact", request))
            {
                Assert.True(updateResponse.IsSuccessStatusCode);
            }

            using (var getResponse = await _client.GetAsync($"/api/v1/vacationrental/{vacationRentalId}/contact"))
            {
                Assert.True(getResponse.IsSuccessStatusCode);

                var returnedData = await getResponse.Content.ReadAsAsync<Domain.Common.Model.Contact>();
                Assert.Equal(request.Forename, returnedData.Forename);
                Assert.Equal(request.Surname, returnedData.Surname);
                Assert.Equal(request.Phone, returnedData.Phone);
                Assert.Equal(request.NativeLanguage, returnedData.NativeLanguage);

                foreach (var aboutMeItem in request.AboutMe)
                {
                    Assert.True(returnedData.AboutMe.ContainsKey(aboutMeItem.Key), $"There should be an about me for language {aboutMeItem.Key}");
                }
            }
        }

        [Fact]
        public async Task GivenAContactWithoutPhoneNumber_WhenUpdateContact_ThenBadRequestIsReturned()
        {
            var vacationRentalId = _rnd.Next();
            var request = new
            {
                Forename = "Flash",
                Surname = "Gordan",
                NativeLanguage = "English",
                OtherSpokenLanguages = new[] { "Spanish" },
                AboutMe = "Fastest man alive"
            };

            using (var updateResponse = await _client.PutAsJsonAsync($"/api/v1/vacationrental/{vacationRentalId}/contact", request))
            {
                Assert.Equal(HttpStatusCode.BadRequest, updateResponse.StatusCode);
            }
        }
    }
}
