using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage, RentACarContext>,ICarImageDal
    {
        public List<CarImageDetailDto> GetByCarId(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cı in context.CarImage
                             join c in context.Car
                             on cı.CarId equals c.CarId
                             join b in context.Brand
                             on cı.BrandId equals b.BrandId
                             join co in context.Color
                             on cı.ColorId equals co.ColorId
                             select new CarImageDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Id = cı.Id,
                                 //ImagePath = cı.ImagePath,
                                 Date = cı.Date,
                                 Year = c.Year,
                                 ImagePath = (from cm in context.CarImage
                                              where
                                           cm.CarId == c.CarId
                                              select cm.ImagePath).FirstOrDefault()
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
