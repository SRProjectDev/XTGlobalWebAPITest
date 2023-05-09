using FruityviceAPI.Models;

namespace FruityviceAPI.Services.Interface
{
    public interface IFruityviceAPIService
    {
        Task<List<FruityviceResponseModel>> GetAllFruits();
        Task<List<FruityviceResponseModel>> GetFruitsByFamily(string family);
    }
}
