﻿using System.Collections.Generic;
using System.Linq;

namespace CarRent.Models
{
    public class MockCarRepo : ICRUDCarRepo
    {
        private List<Car> _carList;


        public MockCarRepo()
        {
            _carList = new List<Car>()
            {
             new Car(){Id = 1, Make="Honda",Model="Accord", Trim="EXL", Vin="1234567689", Millage="10000000",  },
             new Car(){Id = 2, Make="Honda",Model="Accord", Vin="12345676890", },
             new Car(){Id = 3, Make="Honda",Model="Accord",  Vin="01234567689",  }
            };
        }

        public Car Add(Car car)
        {
            car.Id=_carList.Max(e => e.Id) + 1;
            _carList.Add(car);
            return car;
        }

        public List<Company> Companies()
        {
            throw new System.NotImplementedException();
        }

        public Car Delete(int Id)
        {
           Car car =  _carList.FirstOrDefault(e=>e.Id == Id);
            if (car != null)
            {
                _carList.Remove(car);
            }
            return car;
        }

        public IEnumerable<Car> GetAllCar()
        {
            return _carList;
        }

        public Car GetCar(int Id)
        {
            return _carList.FirstOrDefault(e => e.Id == Id);
        }

        public List<Typ> Types()
        {
            throw new System.NotImplementedException();
        }

        public Car Update(Car carUpdate)
        {
            Car car = _carList.FirstOrDefault(e=> e.Id==carUpdate.Id);
            if (car != null)
            {
                car.Make = carUpdate.Make;
                car.Model = carUpdate.Model;
                car.Trim = carUpdate.Trim;
                car.Vin = carUpdate.Vin;
                car.Millage = carUpdate.Millage;
                car.Price = carUpdate.Price;
            }
            return car;
        }

        void ICRUDCarRepo.Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
    }

}

