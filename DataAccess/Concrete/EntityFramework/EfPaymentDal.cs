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
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, RentACarContext>, IPaymentDal
    {
        public List<PaymentDetailDto> GetPaymentsDetails(Expression<Func<PaymentDetailDto, bool>> filter = null)
        {
           using(RentACarContext context = new RentACarContext())
            {
                var result = from p in context.Payment
                             join r in context.Rental
                             on p.RentalId equals r.RentalId
                             join c in context.Car
                             on r.CarId equals c.CarId
                             join cu in context.Customer
                             on p.CustomerId equals cu.CustomerId
                             join u in context.User
                             on cu.UserId equals u.UserId
                             select new PaymentDetailDto
                             {
                                 Id= p.Id,
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 UserId = u.UserId,
                                 CarName = c.CarName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CustomerFullName = $"{u.FirstName} {u.LastName}"
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();

            }
        }
    }
}
