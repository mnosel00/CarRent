using System.Collections.Generic;

namespace CarRent.Models
{
    public interface ICRUDCarRepo
    {
        Car GetCar(int Id);
        IEnumerable<Car> GetAllCar();
        Car Add(Car car);
        Car Update(Car carUpdate);
        Car Delete (int Id);
    }
}
