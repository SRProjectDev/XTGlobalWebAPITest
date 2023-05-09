using FruityviceAPI.Models;
using FruityviceAPI.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FruityviceAPI.Services.Implementation
{
    public class FruityviceAPIService : IFruityviceAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public FruityviceAPIService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        /// <summary>
        /// Fruityvice API call to get all fruits
        /// </summary>
        /// <returns>Returns List of Fruits</returns>
        public async Task<List<FruityviceResponseModel>> GetAllFruits()
        {
            List<FruityviceResponseModel> fruitModels = new List<FruityviceResponseModel>();
            try
            {
                var allFruitAPI = string.Concat(_configuration["FruityviceAPI:BaseURL"], _configuration["FruityviceAPI:AllFruits"]);

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, allFruitAPI);

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(resultString))
                    {
                        fruitModels = JsonConvert.DeserializeObject<List<FruityviceResponseModel>>(resultString);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return fruitModels;
        }

        /// <summary>
        /// Fruityvice API call to get fruits by family name
        /// </summary>
        /// <param name="family">Fruit Family</param>
        /// <returns>Returns List of Fruits By Family</returns>
        public async Task<List<FruityviceResponseModel>> GetFruitsByFamily(string family)
        {
            List<FruityviceResponseModel> fruitModels = new List<FruityviceResponseModel>();
            try
            {

                var fruitByFamilyAPI = string.Concat(_configuration["FruityviceAPI:BaseURL"], string.Format(_configuration["FruityviceAPI:FruitsByFamily"], family));

                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, fruitByFamilyAPI);

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(resultString))
                    {
                        fruitModels = JsonConvert.DeserializeObject<List<FruityviceResponseModel>>(resultString);
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            return fruitModels;
        }
    }
}