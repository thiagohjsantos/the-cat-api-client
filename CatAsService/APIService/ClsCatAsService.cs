using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CatAsService.APIService
{
    /// <summary>
    /// Class responsible for REST requests.
    /// </summary>
    public class ClsCatAsService
    {
        string ApiKey = Program.ApiKey;

        public List<CatModel> GetBreeds()
        {
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest($"/v1/breeds/", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<CatModel> results = JsonConvert.DeserializeObject<List<CatModel>>(response.Content.ToString());

                return results;
            }
            else
            {
                MessageBox.Show($"The breeds list could not be loaded!");
                MessageBox.Show(response.Content, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CatModel GetCharacteristicsByID(string Id)
        {
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest($"/v1/breeds/{Id}", Method.Get);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                CatModel results = JsonConvert.DeserializeObject<CatModel>(response.Content.ToString());
                return results;
            }
            else
            {
                MessageBox.Show($"The operation could not be completed!");
                MessageBox.Show(response.Content, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CatModel GetImages(string Id)
        {
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest($"/v1/images/{Id}", Method.Get);
            var body = @"";

            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                CatModel results = JsonConvert.DeserializeObject<CatModel>(response.Content.ToString());
                return results;
            }
            else
            {
                MessageBox.Show($"Image for display was not found.");
                MessageBox.Show(response.Content);
                return null;
            }
        }

        public bool AddFavorite(string Id)
        {
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest("/v1/favourites/", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", ApiKey);
            var body = @"{" + "\n" +
            @$"	""image_id"":""{Id}""," + "\n" +
            @"	""sub_id"":""user-123"" " + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"The operation could not be completed!");
                MessageBox.Show(response.Content, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Tuple<CatModel, CatModel>> GetFavorites()
        {
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest("/v1/favourites?sub_id=User-123", Method.Get);
            var request2 = new RestRequest($"/v1/breeds/", Method.Get);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", ApiKey);
            RestResponse response = client.Execute(request);
            RestResponse response2 = client.Execute(request2);

            if (response.StatusCode == HttpStatusCode.OK && response2.StatusCode == HttpStatusCode.OK)
            {
                List<CatModel> favoritesResult = JsonConvert.DeserializeObject<List<CatModel>>(response.Content.ToString());
                List<CatModel> breedsResult = JsonConvert.DeserializeObject<List<CatModel>>(response2.Content.ToString());
                var result = new List<Tuple<CatModel, CatModel>>();

                foreach (CatModel obj in breedsResult)
                {
                    foreach (CatModel objFavorite in favoritesResult.Where(f => f.ImageId == obj.ReferenceImageId))
                    {
                        result.Add(Tuple.Create(obj, objFavorite));
                    }
                }
                return result;
            }
            else
            {
                MessageBox.Show($"Your favorites list could not be loaded!");
                MessageBox.Show(response.Content, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool DeleteFavorite(string Id)
        {
            var client = new RestClient("https://api.thecatapi.com");
            var request = new RestRequest($"/v1/favourites/{Id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", ApiKey);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"The operation could not be completed!");
                MessageBox.Show(response.Content, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
