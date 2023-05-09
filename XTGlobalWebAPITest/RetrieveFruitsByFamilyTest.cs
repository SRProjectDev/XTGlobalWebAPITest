using AutoMapper; 
using FruityviceAPI.Models;
using FruityviceAPI.Services.Interface;
using Moq;
using Newtonsoft.Json;
using XTGlobal_WebAPI.Models;
using XTGlobalWebAPI.BusinessLayer.Implementations;
using XTGlobalWebAPI.BusinessLayer.Interfaces;
using XTGlobalWebAPI.Models;

namespace XTGlobalWebAPITest
{
    public class RetrieveFruitsByFamilyTest
    {
        private Mock<IFruityviceAPIService> _mockFruityviceAPIService;
        private Mock<IMapper> _mockMapper;

        private IRetrieveFruitsByFamily _retrieveFruitsByFamily;

        [SetUp]
        public void Setup()
        {
            //Mock up IFruityviceAPIService & IMapper
            _mockFruityviceAPIService = new Mock<IFruityviceAPIService>();
            _mockMapper = new Mock<IMapper>();

            //Instantiate the RetrieveFruitsByFamily Object
            _retrieveFruitsByFamily = new RetrieveFruitsByFamily(_mockFruityviceAPIService.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Given_I_Have_Fruit_Family_When_I_Called_RetrieveFruitsByFamily_Then_I_Verify_Map_Is_Called_Once()
        {
            //Given: I Have Fruit Family
            FruitRequestModel fruitRequestModel = new FruitRequestModel
            {
                FruitFamily = "Test"
            };

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

            //AND: I Set up GetFruitsByFamily method from API Service
            _mockFruityviceAPIService.Setup(x => x.GetFruitsByFamily(fruitRequestModel.FruitFamily)).Returns(Task.FromResult(fruityviceList));

            //When: I Called RetrieveFruitsByFamily methods
            var fruitList = await _retrieveFruitsByFamily.Retrieve(fruitRequestModel);

            //Then: I Verify Map is Called Once
            _mockMapper.Verify(x => x.Map<List<FruitModel>>(fruityviceList), Times.Once);
        }

        [Test]
        public async Task Given_I_Have_Fruit_Family_When_I_Called_RetrieveFruitsByFamily_Then_I_Verify_Returned_FruitList()
        {
            //Given: I Have Fruit Family
            FruitRequestModel fruitRequestModel = new FruitRequestModel
            {
                FruitFamily = "Test"
            };

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

            //AND: I Set up GetFruitsByFamily method from API Service
            _mockFruityviceAPIService.Setup(x => x.GetFruitsByFamily(fruitRequestModel.FruitFamily)).Returns(Task.FromResult(fruityviceList));

            //AND: I Set up Mapper to Map to FruitList
            _mockMapper.Setup(x => x.Map<List<FruitModel>>(fruityviceList)).Returns(fruitList);

            //When: I Called RetrieveFruitsByFamily methods
            var result = await _retrieveFruitsByFamily.Retrieve(fruitRequestModel);

            //Then: I Verify Returned FruitList
            var expectedResult = JsonConvert.SerializeObject(fruitList);
            var actualResult = JsonConvert.SerializeObject(result);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task Given_I_Have_Fruit_Family_As_Empty_When_I_Called_RetrieveFruitsByFamily_Then_I_Verify_Returned_FruitList_Is_Empty()
        {
            //Given: I Have Fruit Family as Empty
            FruitRequestModel fruitRequestModel = new FruitRequestModel
            {
                FruitFamily = ""
            };

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

            //AND: I Set up GetFruitsByFamily method from API Service
            _mockFruityviceAPIService.Setup(x => x.GetFruitsByFamily(fruitRequestModel.FruitFamily)).Returns(Task.FromResult(fruityviceList));

            //AND: I Set up Mapper to Map to FruitList
            _mockMapper.Setup(x => x.Map<List<FruitModel>>(fruityviceList)).Returns(It.IsAny<List<FruitModel>>());

            //When: I Called RetrieveFruitsByFamily methods
            var result = await _retrieveFruitsByFamily.Retrieve(fruitRequestModel);

            //Then: I Verify Returned FruitList

            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}