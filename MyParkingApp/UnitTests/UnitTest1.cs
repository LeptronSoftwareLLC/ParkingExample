using Moq;
using MyParkingApp.Data.Remote;
using MyParkingApp.Data.Remote.APIObjects;
using MyParkingApp.ViewModels;
using NUnit.Framework;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int locationid = 1;
            Mock<INavigationService> nav = new Mock<INavigationService>();
            Mock<IParkingServiceAPI> api = new Mock<IParkingServiceAPI>();
            Location testLoc = new Location(locationid, "test", 2, 10);
            List<Location> locations = new List<Location> { testLoc };

            List<Location> locationsAdd = new List<Location> { new Location(locationid, "test", 3, 10) };
            api.Setup(a => a.GetAll()).Returns(Task.FromResult(locations));
            api.Setup(a => a.AddCar(locationid, It.IsAny<string>())).Returns(Task.FromResult(locationsAdd));

            var model = new MainPageViewModel(nav.Object, api.Object);
            model.ItemLocation = testLoc;
            var statusMessage = model.StatusMessage;
            model.AddCommand.Execute();
            var statusMessageAdd = model.StatusMessage;
            Assert.IsFalse(statusMessageAdd == statusMessage);

        }
    }
}