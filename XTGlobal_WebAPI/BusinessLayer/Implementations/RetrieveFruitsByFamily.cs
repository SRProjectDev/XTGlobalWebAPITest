using AutoMapper;
using FruityviceAPI.Services.Interface;
using XTGlobal_WebAPI.Models;
using XTGlobalWebAPI.BusinessLayer.Interfaces;
using XTGlobalWebAPI.Models;

namespace XTGlobalWebAPI.BusinessLayer.Implementations
{
    public class RetrieveFruitsByFamily : IRetrieveFruitsByFamily
    {
        private readonly IFruityviceAPIService _fruityviceAPIService;
        private readonly IMapper _mapper;
        public RetrieveFruitsByFamily(IFruityviceAPIService fruityviceAPIService, IMapper mapper)
        {
            _fruityviceAPIService = fruityviceAPIService;
            _mapper = mapper;
        }

        /// <summary>
        /// Business Layer to get fruits by family from API Call and map to List of FruitModel
        /// </summary>
        /// <param name="filterModel">Fruit Family</param>
        /// <returns>Returns List of Fruit Model</returns>
        public async Task<List<FruitModel>> Retrieve(FruitRequestModel filterModel)
        {
            List<FruitModel> fruitModels = new List<FruitModel>();

            if (!string.IsNullOrEmpty(filterModel?.FruitFamily))
            {
                var fruityviceModel = await _fruityviceAPIService.GetFruitsByFamily(filterModel.FruitFamily);

                if (fruityviceModel?.Count > 0)
                {
                    fruitModels = _mapper.Map<List<FruitModel>>(fruityviceModel);
                }
            }

            return fruitModels;
        }
    }
}
