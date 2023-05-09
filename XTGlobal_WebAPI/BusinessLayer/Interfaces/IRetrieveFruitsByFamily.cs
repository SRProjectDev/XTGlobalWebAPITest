using XTGlobal_WebAPI.Models;
using XTGlobalWebAPI.Models;

namespace XTGlobalWebAPI.BusinessLayer.Interfaces
{
    public interface IRetrieveFruitsByFamily
    {
        Task<List<FruitModel>> Retrieve(FruitRequestModel filterModel);
    }
}
