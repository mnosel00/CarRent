using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCar
{
    internal class MemoCarRepo : ICRUDCarRepo
    {
        private Dictionary<int, Car> cars = new Dictionary<int, Car>();
        private int index = 1;

        private int nextIndex()
        {
            return index++;
        }
        public Car Add(Car car)
        {
           car.Id = nextIndex();
            cars.Add(car.Id, car);
            return car;
        }

        public Car Delete(int Id)
        {

            throw new NotImplementedException();

        }

        public IEnumerable<Car> GetAllCar()
        {
            throw new NotImplementedException();
        }

        public Car GetCar(int Id)
        {
            throw new NotImplementedException();
        }

        public Car Update(Car carUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
