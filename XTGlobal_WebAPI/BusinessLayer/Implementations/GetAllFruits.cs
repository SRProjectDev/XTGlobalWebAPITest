using AutoMapper;
using FruityviceAPI.Services.Interface;
using System.Collections.Generic;
using XTGlobal_WebAPI.Models;
using XTGlobalWebAPI.BusinessLayer.Interfaces;

namespace XTGlobalWebAPI.BusinessLayer.Implementations
{
    public class GetAllFruits : IGetAllFruits
    {
        private readonly IFruityviceAPIService _fruityviceAPIService;
        private readonly IMapper _mapper;
        public GetAllFruits(IFruityviceAPIService fruityviceAPIService, IMapper mapper)
        {
            _fruityviceAPIService = fruityviceAPIService;
            _mapper = mapper;
        }

        /// <summary>
        /// Business Layer to get all fruits from API Call and map to List of FruitModel
        /// </summary>
        /// <returns>Returns List of FruitModel</returns>
        public async Task<List<FruitModel>> Get()
        {
            var fruityviceModel = await _fruityviceAPIService.GetAllFruits();

            List<FruitModel> fruitModels = new List<FruitModel>();
            
            if (fruityviceModel?.Count > 0)
            {
                fruitModels = _mapper.Map<List<FruitModel>>(fruityviceModel);
            }

            return fruitModels;
        }
    }
}
