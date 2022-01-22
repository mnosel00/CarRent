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
            CreateViewModel aCar = (CreateViewModel)controller.Create(new CreateViewModel(){ Id = 1, Make = "Honda", Model = "Accord", Type = "Sport", Trim = "EXL", Vin = "1234567689", Millage = "10000000", Price = 80000 });
            Assert.Equal(1, aCar.Id);
            

        }
    }
}
