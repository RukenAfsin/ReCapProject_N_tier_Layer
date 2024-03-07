using IResult = Core.Utilities.Result.IResult;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IDataResult<List<CarImageDetailDto>> GetAll();
        IDataResult <List<CarImageDetailDto>> GetByCarId(int carId);
        IDataResult<CarImage> GetByImageId(int imageId);

    }
}