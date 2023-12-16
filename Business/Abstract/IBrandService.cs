using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
      IDataResult <Brand> GetById(int id);
      IDataResult<List<Brand>> GetAll();
      IResult Add(Brand brand);
      IResult Update(Brand brand);
      IResult Delete(Brand brand);
      IDataResult<List<BrandDetailDto>> GetBrandDetails();
    }
}
