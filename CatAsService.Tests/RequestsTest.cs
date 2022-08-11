using CatAsService.APIService;
using RestSharp;
using System;
using System.Net;
using Xunit;

namespace CatAsService.Tests
{
    public class RequestsTest
    {
        [Fact]
        public void VerifyGetBreeds()
        {
            //arrange
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest($"/v1/breeds/", Method.Get);

            //act
            RestResponse response = client.Execute(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("abys", "Abyssinian")]
        [InlineData("ebur", "European Burmese")]
        [InlineData("mala", "Malayan")]
        [InlineData("sphy", "Sphynx")]
        [InlineData("ycho", "York Chocolate")]
        public void VerifyGetCharacteristicsByID(string Id, string Name)
        {
            //arrange
            var ApiCatAsService = new ClsCatAsService();

            //act
            var result = ApiCatAsService.GetCharacteristicsByID(Id);

            //Assert
            Assert.Equal(result.Name, Name);
        }
    }
}
