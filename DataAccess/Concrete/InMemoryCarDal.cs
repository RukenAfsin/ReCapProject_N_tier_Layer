using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
            new Car {CarId=1, BrandId=1, ColorId=1,DailyPrice=100, Description="otomatik",Year=1995},

            new Car { CarId = 2, BrandId = 1, ColorId = 2, DailyPrice = 10000, Description = "otomatik", Year = 1995 },

            new Car { CarId = 3, BrandId = 2, ColorId = 3, DailyPrice = 50000, Description = "otomatik", Year = 1995 },

            new Car { CarId = 4, BrandId = 1, ColorId = 3, DailyPrice = 80000, Description = "otomatik", Year = 1995 }};
        }
        public void Add(Car car)
        {
           _car.Add(car);
        }

        public void Delete(Car car)
        {
            var result = _car.SingleOrDefault(c=>c.CarId == car.CarId);
            _car.Remove(result);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByColor(int colorid)
        {
            return _car.Where(c=>c.ColorId==colorid).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var update= _car.SingleOrDefault(x=>x.CarId==car.CarId);
            update.DailyPrice = car.DailyPrice;
            update.Description = car.Description;
        }
    }
}
