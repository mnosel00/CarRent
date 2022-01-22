using CarRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICRUDCarRepo _carRepo;

        public HomeController(ICRUDCarRepo carRepo)
        {
            _carRepo = carRepo;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult List()
        {
            var model = _carRepo.GetAllCar();
            return View(model);
        }

        public IActionResult Details(int Id)
        {
            Car car = _carRepo.GetCar(Id);
            if (car==null)
            {
                Response.StatusCode = 404;
                return View("IdNotFound" ,Id);
            }

            DetailsViewModel detailsViewModel = new DetailsViewModel()
            {
                Car = car,
            };

            return View(car);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateViewModel newmodel)
        {
            if (ModelState.IsValid)
            {
                /* Car newCar = new Car()
                 {
                     Make = newmodel.Make,
                     Model = newmodel.Model,
                     Type = newmodel.Type,
                     Trim = newmodel.Trim,
                     Vin = newmodel.Vin,
                     ReleaseDate = newmodel.ReleaseDate,
                     Millage = newmodel.Millage,
                     Price = newmodel.Price
                 };
                 _carRepo.Add(newCar);
                 return RedirectToAction("Details", new { Id = newCar.Id });*/

                Car newCar = new Car()
                {
                    Make = newmodel.Make,
                    Model = newmodel.Model,
                    Type = newmodel.Type,
                    Trim = newmodel.Trim,
                    Vin = newmodel.Vin,
                    ReleaseDate = newmodel.ReleaseDate,
                    Millage = newmodel.Millage,
                    Price = newmodel.Price
                };
                _carRepo.Add(newCar);
                return RedirectToAction("Details", new { Id = newCar.Id });
            }

            return View();


        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Car car = _carRepo.GetCar(Id);
            EditViewModel editViewModel = new EditViewModel
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Type = car.Type,
                Trim = car.Trim,
                Vin = car.Vin,
                ReleaseDate = car.ReleaseDate,
                Millage = car.Millage,
                Price = car.Price
            };
            return View(editViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(EditViewModel newmodel)
        {
            if (ModelState.IsValid)
            {
                Car car = _carRepo.GetCar(newmodel.Id);
                car.Make = newmodel.Make;
                car.Model = newmodel.Model;
                car.Type = newmodel.Type;
                car.Trim = newmodel.Trim;
                car.Vin = newmodel.Vin;
                car.ReleaseDate = newmodel.ReleaseDate;
                car.Millage = newmodel.Millage;
                car.Price = newmodel.Price;

                _carRepo.Update(car);
                return RedirectToAction("List");


            }

            return View();


        }




        [Authorize]
        public IActionResult Delete(int Id)
        {
            _carRepo.Delete(Id);
            return RedirectToAction("List");
        }
    }
}
