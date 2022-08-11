using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatAsService.APIService
{
    public class CatModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("temperament")]
        public string Temperament { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("reference_image_id")]
        public string ReferenceImageId { get; set; }
        [JsonProperty("image_id")]
        public string ImageId { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
