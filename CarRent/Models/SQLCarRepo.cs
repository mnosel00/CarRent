using System.Collections.Generic;

namespace CarRent.Models
{
    public class SQLCarRepo : ICRUDCarRepo
    {
        private readonly AppDbContext context;
        public SQLCarRepo(AppDbContext context)
        {
            this.context = context;
        }
        public Car Add(Car car)
        {
            context.Card.Add(car);
            context.SaveChanges();
            return car;
        }

        public void Delete(int Id)
        {
            context.Card.Remove(context.Card.Find(Id));
            context.SaveChanges();
        }

        /*public Car Delete(int Id)
        {
            Car car = context.Card.Find(Id);
            if(car != null)
            {
                context.Card.Remove(car);
                context.SaveChanges();
            }
            return car;
        }*/


        public IEnumerable<Car> GetAllCar()
        {
            return context.Card;
        }

        public Car GetCar(int Id)
        {
            return context.Card.Find(Id);
        }

        public Car Update(Car carUpdate)
        {
            var car = context.Card.Attach(carUpdate);
            car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return carUpdate;
        }

      
    }
}
