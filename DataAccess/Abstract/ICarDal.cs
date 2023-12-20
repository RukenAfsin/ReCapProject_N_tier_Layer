using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();

        List<CarDetailDto> GetCarsByBrandId(Expression<Func<CarDetailDto, bool>> filter = null);

        List<CarDetailDto> GetCarsByColorId(Expression<Func<CarDetailDto, bool>> filter = null);

    }
}
