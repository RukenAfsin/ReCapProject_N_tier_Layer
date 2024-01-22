using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using IResult = Core.Utilities.Result.IResult;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;


        public CarImageManager(ICarImageDal carımdageDal, IFileHelper fileHelper)
        {
            _carImageDal = carımdageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();

        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        //[CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImageDetailDto>>(GetDefaultImage(carId).Data, Message.ImageError);
               
            }
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetByCarId(c => c.CarId == carId), Message.ImageSuccess);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IDataResult<List<CarImageDetailDto>> GetDefaultImage(int carId)
        {

            List<CarImageDetailDto> carImage = new List<CarImageDetailDto>();
            carImage.Add(new CarImageDetailDto { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImageDetailDto>>(carImage);
        }
    }
}