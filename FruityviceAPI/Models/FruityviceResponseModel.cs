using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FruityviceAPI.Models
{
    public class FruityviceResponseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("genus")]
        public string Genus { get; set; }

        [JsonProperty("nutritions")]
        public FruityviceNutritions Nutritions { get; set; }
    }

    public class FruityviceNutritions
    {
        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("fat")]
        public double Fat { get; set; }

        [JsonProperty("sugar")]
        public double Sugar { get; set; }

        [JsonProperty("carbohydrates")]
        public double Carbohydrates { get; set; }

        [JsonProperty("protein")]
        public double Protein { get; set; }
    }
}
