using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Playwright_Specflow.Models
{
 

    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; } = default;

        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("status")]
        public string Status { get; set; } = "";

        [JsonProperty("species")]
        public string Species { get; set; } = "";

        [JsonProperty("type")]
        public string Type { get; set; } = "";

        [JsonProperty("gender")]
        public string Gender { get; set; } = "";

        [JsonProperty("origin")]
        public Origin Origin { get; set; } = new();

        [JsonProperty("location")]
        public Location Location { get; set; } = new();

        [JsonProperty("image")]
        public string Image { get; set; } = "";

        [JsonProperty("episode")]
        public List<string> Episode { get; set; } = new();

        [JsonProperty("url")]
        public string Url { get; set; } = "";

        [JsonProperty("created")]
        public DateTime Created { get; set; } = DateTime.MinValue;
    }

    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("url")]
        public string Url { get; set; } = "";
    }

    public class Origin
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("url")]
        public string Url { get; set; } = "";
    }
}
