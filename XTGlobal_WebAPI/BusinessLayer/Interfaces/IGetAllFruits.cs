using XTGlobal_WebAPI.Models;

namespace XTGlobalWebAPI.BusinessLayer.Interfaces
{
    public interface IGetAllFruits
    {
        Task<List<FruitModel>> Get();
    }
}
