//using Moq;
//using Xunit;

//namespace ECommerce.Tests
//{
//    public class SmartphoneTests
//    {
//        private Mock<ISmartphoneRepository> _smartphoneRepo;
//        public SmartphoneTests()
//        {
//            _smartphoneRepo = new Mock<ISmartphoneRepository>();
//        }
//        [Fact]
//        public void Test1()
//        {
//            _smartphoneRepo.Setup(r => r.GetSmartphoneById(1))
//                .Returns(new Smartphone { ID = 1, Name = "Hello" });

//            Assert.True(_smartphoneRepo.Object.GetSmartphoneById(1).Name == "Hello");
//        }
//    }
//}
