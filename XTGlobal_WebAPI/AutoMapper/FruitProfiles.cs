using AutoMapper;
using FruityviceAPI.Models;
using XTGlobal_WebAPI.Models;

namespace XTGlobalWebAPI.AutoMapper
{
    public class FruitProfiles : Profile
    {
        public FruitProfiles()
        {
            CreateMap<FruityviceNutritions, Nutritions>();
            CreateMap<FruityviceResponseModel, FruitModel>();
        }
    }
}
