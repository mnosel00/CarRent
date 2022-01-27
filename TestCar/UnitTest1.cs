using CarRent.Controllers;
using CarRent.Models;
using System;
using Xunit;
using Moq;
using FluentAssertions;



using Microsoft.AspNetCore.Mvc;


namespace TestCar
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            

            ICRUDCarRepo _carList = new MemoCarRepo();
            HomeController controller = new HomeController(_carList);
            CreateViewModel viewModel = new CreateViewModel();
            Assert.NotNull(viewModel);



        }


        [Fact]
        public void TestCreate()
        {
            ICRUDCarRepo cars = new MemoCarRepo();
            HomeController controller = new HomeController(cars);
            controller.Create(new CreateViewModel() { Id = 4, Make = "Honda", Model = "Accord", Trim = "EXL", Vin = "1234567689", Millage = "10000000", Price = 80000 });

        }

        [Fact]
        public void TestAdd()
        {

            ICRUDCarRepo _carList = new MemoCarRepo();
            HomeController controller = new HomeController(_carList);

            var res = controller.Create();

            res.Should().NotBeNull();
            res.Should().BeOfType<ViewResult>();
            res.Should().BeAssignableTo<IActionResult>();
        }



        [Fact]
        public void TestAddPost()
        {
            var mock = new Mock<ICRUDCarRepo>();
            
            var controller = new HomeController(mock.Object);
            var res = controller.Create(new CreateViewModel() { Id = 1 });

            res.Should().NotBeNull();
            res.Should().BeOfType<RedirectToActionResult>();
            res.Should().BeAssignableTo<IActionResult>();


            mock.Verify(v => v.Add(It.IsAny<Car>()));
            

        }

        [Fact]
        public void TestDelete()
        {

            var Car = new Car() { Id=1};
        
            var mock = new Mock<ICRUDCarRepo>();
            var controller = new HomeController(mock.Object);

           
            var res = controller.Delete(1);


            res.Should().NotBeNull();
            res.Should().BeOfType<RedirectToActionResult>();
            res.Should().BeAssignableTo<IActionResult>();


           mock.Verify(v => v.Delete(1), Times.Once());
        }

        [Fact]
        public void TestUpdate()
        {

            var Car = new Car() { Id = 1 };
            var Car2 = new EditViewModel() { Id = 1 };
            var mock = new Mock<ICRUDCarRepo>();
            mock.Setup(v => v.GetCar(1)).Returns(Car);
            var controller = new HomeController(mock.Object);


            var res = controller.Edit(Car2 );


            res.Should().NotBeNull();
            res.Should().BeOfType<RedirectToActionResult>();
            res.Should().BeAssignableTo<IActionResult>();


            mock.Verify(v => v.Update(It.IsAny<Car>()), Times.Once());
        }
    }
}
