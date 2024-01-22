using Core.DataAccess.EntityFramework;
using Core.Utilities.Result;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsByCarId(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rent in context.Rental
                             join car in context.Car
                       on rent.CarId equals car.CarId
                             join customer in context.Customer
                                 on rent.CustomerId equals customer.CustomerId
                             join user in context.User
                                 on customer.UserId equals user.UserId
                             join brand in context.Brand
                                 on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rent.RentalId,
                                 CarId = car.CarId,
                                 ModelFullName = $"{brand.BrandName} {car.CarName}",
                                 CustomerId = customer.CustomerId,
                                 CustomerFullName = $"{user.FirstName} {user.LastName}",
                                 ReturnDate = rent.ReturnDate,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rent.RentDate,
                                 //DeliveryStatus = rent.DeliveryStatus
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public List<RentalDetailDto> GetRentalsByCustomerId(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rent in context.Rental
                             join car in context.Car
                       on rent.CarId equals car.CarId
                             join customer in context.Customer
                                 on rent.CustomerId equals customer.CustomerId
                             join user in context.User
                                 on customer.UserId equals user.UserId
                             join brand in context.Brand
                                 on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rent.RentalId,
                                 CarId = car.CarId,
                                 ModelFullName = $"{brand.BrandName} {car.CarName}",
                                 CustomerId = customer.CustomerId,
                                 CustomerFullName = $"{user.FirstName} {user.LastName}",
                                 ReturnDate = rent.ReturnDate,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rent.RentDate,
                                 //DeliveryStatus = rent.DeliveryStatus
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rent in context.Rental
                             join car in context.Car
                       on rent.CarId equals car.CarId
                             join customer in context.Customer
                                 on rent.CustomerId equals customer.CustomerId
                             join user in context.User
                                 on customer.UserId equals user.UserId
                             join brand in context.Brand
                                 on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rent.RentalId,
                                 CarId = car.CarId,
                                 ModelFullName = $"{brand.BrandName} {car.CarName}",
                                 CustomerId = customer.CustomerId,
                                 CustomerFullName = $"{user.FirstName} {user.LastName}",
                                 ReturnDate = rent.ReturnDate,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = rent.RentDate,
                                 CarName = car.CarName,
                                 //DeliveryStatus = rent.DeliveryStatus
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }


        //public List<RentalDetailDto> CheckRental(Expression<Func<RentalDetailDto, bool>> filter = null)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var result = from rent in context.Rental
        //                     join car in context.Car
        //               on rent.CarId equals car.CarId
        //                     join customer in context.Customer
        //                         on rent.CustomerId equals customer.CustomerId
        //                     join user in context.User
        //                         on customer.UserId equals user.UserId
        //                     join brand in context.Brand
        //                         on car.BrandId equals brand.BrandId
        //                     select new RentalDetailDto
        //                     {
        //                         RentalId = rent.RentalId,
        //                         CarId = car.CarId,
        //                         CustomerId = customer.CustomerId,
        //                         CustomerFullName = $"{user.FirstName} {user.LastName}",
        //                         ReturnDate = rent.ReturnDate,
        //                         RentDate = rent.RentDate,
        //                         CarName = car.CarName,
        //                         //DeliveryStatus = rent.DeliveryStatus
        //                     };
        //        return filter == null
        //            ? result.ToList()
        //            : result.Where(filter).ToList();
        //    }
        //}
    }
}