using Core.DataAccess;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetailDto>GetRentalsByCarId(Expression<Func<RentalDetailDto, bool>> filter = null);
        List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null);
        List<RentalDetailDto> GetRentalsByCustomerId(Expression<Func<RentalDetailDto, bool>> filter = null);
       // List<RentalDetailDto> CheckRental(Expression<Func<RentalDetailDto, bool>> filter = null);

    }
}
