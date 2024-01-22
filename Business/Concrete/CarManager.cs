using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transactions;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
             _carDal= carDal;
        }
        //[SecuredOperation("car.add,admin")]
        //[ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           if(car.Description.Length>2 && car.DailyPrice>0)
            {
               _carDal.Add(car);
                return new SuccessResult(Message.CarAdded);
            }
           return new ErrorResult();
        }

        public IResult Delete(Car car)
        {
             _carDal.Delete(car);
            return new SuccessResult();
        }

        //[SecuredOperation("car.add,admin")]
        //[CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll());
        }



        //[SecuredOperation("car.add,admin")]
        //[CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailByColorAndBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailByColorAndBrand(x => x.ColorId == colorId && x.BrandId == brandId));
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByBrandId(p=>p.BrandId==brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByColorId(p => p.ColorId == colorId));

        }


        // [TransactionScopeAspect]

        //[CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult();
        }

        //public IResult CheckColorAndBrand(int id1, int id2)
        //{
        // var result= _carDal.GetAll(x=>x.ColorId==id1 && x.BrandId==id2);
        //    if (result.Any())
        //    {
        //        return new SuccessResult();
        //    }

        //    return new ErrorResult();
        
        //}
       
    }
}
