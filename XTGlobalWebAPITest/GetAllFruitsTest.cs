using AutoMapper; 
using FruityviceAPI.Models;
using FruityviceAPI.Services.Interface;
using Moq;
using Newtonsoft.Json;
using XTGlobal_WebAPI.Models;
using XTGlobalWebAPI.BusinessLayer.Implementations;
using XTGlobalWebAPI.BusinessLayer.Interfaces;

namespace XTGlobalWebAPITest
{
    public class GetAllFruitsTest
    {
        private Mock<IFruityviceAPIService> _mockFruityviceAPIService;
        private Mock<IMapper> _mockMapper;

        private IGetAllFruits _getAllFruits;

        [SetUp]
        public void Setup()
        {
            //Mock up IFruityviceAPIService & IMapper
            _mockFruityviceAPIService = new Mock<IFruityviceAPIService>();
            _mockMapper = new Mock<IMapper>();

            //Instantiate the GetAllFruits Object
            _getAllFruits = new GetAllFruits(_mockFruityviceAPIService.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Given_I_Have_Fruityvice_List_When_I_Called_GetAllFruits_Then_I_Verify_Map_Is_Called_Once()
        {
            //Given: I Have Fruityvice List
            List<FruityviceResponseModel> fruityviceList = new List<FruityviceResponseModel>()
            {
                new FruityviceResponseModel
                {
                    Family = "Test",
                    Genus = "hjffgh",
                    Id = 1,
                    Name = "Banana",
                    Order = "2",
                    Nutritions = new FruityviceNutritions()
                }
            };

            //AND: I Set up GetAllFruits method from API Service
            _mockFruityviceAPIService.Setup(x => x.GetAllFruits()).Returns(Task.FromResult(fruityviceList));

            //When: I Called GetAllFruits methods
            var fruitList = await _getAllFruits.Get();

            //Then: I Verify Map is Called Once
            _mockMapper.Verify(x => x.Map<List<FruitModel>>(fruityviceList), Times.Once);
        }

        [Test]
        public async Task Given_I_Have_Fruityvice_List_When_I_Called_GetAllFruits_Then_I_Verify_Returned_FruitList()
        {
            //Given: I Have Fruityvice List
            List<FruityviceResponseModel> fruityviceList = new List<FruityviceResponseModel>()
            {
                new FruityviceResponseModel
                {
                    Family = "Test",
                    Genus = "hjffgh",
                    Id = 1,
                    Name = "Banana",
                    Order = "2",
                    Nutritions = new FruityviceNutritions()
                }
            };

            List<FruitModel> fruitList = new List<FruitModel>();

            //AND: I Set up GetAllFruits method from API Service
            _mockFruityviceAPIService.Setup(x => x.GetAllFruits()).Returns(Task.FromResult(fruityviceList));

            //AND: I Set up Mapper to Map to FruitList
            _mockMapper.Setup(x => x.Map<List<FruitModel>>(fruityviceList)).Returns(fruitList);

            //When: I Called GetAllFruits methods
            var result = await _getAllFruits.Get();

            //Then: I Verify Returned FruitList
            var expectedResult = JsonConvert.SerializeObject(fruitList);
            var actualResult = JsonConvert.SerializeObject(result);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}