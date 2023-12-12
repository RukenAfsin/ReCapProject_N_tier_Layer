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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
           using(RentACarContext context = new RentACarContext())
            {
                var result = from customer in context.Customer
                             join user in context.User
                             on customer.UserId equals user.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 CustomerFullName = $"{user.FirstName} {user.LastName}",

                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
