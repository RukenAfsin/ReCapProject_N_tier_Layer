using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailByColorAndBrand(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join co in context.Color
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Year = c.Year,
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {

                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join co in context.Color
                             on c.ColorId equals co.ColorId
                             //join cm in context.CarImage
                             //on c.CarId equals cm.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Year = c.Year,
                                 ImagePath = (from cm in context.CarImage where
                                            cm.CarId == c.CarId select cm.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
                    
            }
        }

        public List<CarDetailDto> GetCarsByBrandId(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join co in context.Color
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Year = c.Year,
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColorId(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join co in context.Color
                             on c.ColorId equals co.ColorId                          
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,                              
                                 Year = c.Year,
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

      
    }
}
