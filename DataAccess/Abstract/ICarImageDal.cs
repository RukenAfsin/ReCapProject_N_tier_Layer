using Core.DataAccess;
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
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
        List<CarImageDetailDto> GetByCarId(Expression<Func<CarImageDetailDto, bool>> filter = null);
        List<CarImageDetailDto> GetAll(Expression<Func<CarImageDetailDto, bool>> filter = null);
    }
}
