using FruityviceAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using XTGlobalWebAPI.BusinessLayer.Interfaces;
using XTGlobalWebAPI.Models;

namespace XTGlobalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruityviceAPIController : ControllerBase
    {
        private readonly IGetAllFruits _getAllFruits;
        private readonly IRetrieveFruitsByFamily _retrieveFruitsByFamily;
        
        public FruityviceAPIController(IGetAllFruits getAllFruits, IRetrieveFruitsByFamily retrieveFruitsByFamily) 
        {
            _getAllFruits = getAllFruits;
            _retrieveFruitsByFamily = retrieveFruitsByFamily;
        }

        /// <summary>
        /// Get All Fruits
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllFruits")]
        public async Task<IActionResult> Fruits()
        {
            var fruits = await _getAllFruits.Get();
            if(fruits?.Count > 0)
            {
                return Ok(fruits);
            }

            return NoContent();
        }

        /// <summary>
        /// API to get all fruits by family
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("FruitsByFamily")]
        public async Task<IActionResult> FruitsByFamily(FruitRequestModel filterModel)
        {
            var fruits = await _retrieveFruitsByFamily.Retrieve(filterModel);
            if (fruits?.Count > 0)
            {
                return Ok(fruits);
            }

            return NoContent();
        }
    }
}
