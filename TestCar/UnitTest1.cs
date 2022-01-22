using CarRent.Controllers;
using CarRent.Models;
using System;
using Xunit;

namespace TestCar
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            ICRUDCarRepo cars = new MemoCarRepo();
            HomeController controller = new HomeController(cars);
            CreateViewModel aCar = (CreateViewModel)controller.Create(new CreateViewModel());
            Assert.Equal(1, aCar.Id);
            

        }
    }
}
