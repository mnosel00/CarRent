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
            

            CreateViewModel viewModel = new CreateViewModel();
            Assert.NotNull(viewModel);



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
