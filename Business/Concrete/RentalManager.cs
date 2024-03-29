﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult();
            }
            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        public IDataResult<Rental> CheckRentalCarId(int carId)
        {
            var rental = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            if (rental != null)
            {
                return new ErrorDataResult<Rental>("Araç müsait değil, kiralanmış durumda");
            }
            return new SuccessDataResult<Rental>("Araç müsait, kiralanabilir durumda");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult CheckRental(Rental entity)
        {
            var result = BusinessRules.Run(
                CheckIfThisCarIsAlreadyRentedInSelectedDateRange(entity),
                CheckIfReturnDateIsBeforeRentDate(entity.ReturnDate, entity.RentDate)
                );
            if (result != null)
            {
                return result;
            }
            return new SuccessResult("You are directed to the payment page");
        }







        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental entity)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == entity.CarId
            && (r.RentDate.Date == entity.RentDate.Date
            || (r.RentDate.Date < entity.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > entity.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult("The car has been rented by someone else in this dates");
            }
            return new SuccessResult();

        }
        private IResult CheckIfThisCarHasBeenReturned(Rental entity)
        {
            var result = _rentalDal.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (entity.ReturnDate == null || entity.ReturnDate > result.RentDate)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult();
                }
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCustomerId(int id)
        {
           return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsByCustomerId(x=>x.CustomerId==id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsByCarId(x=>x.CarId== carId));
        }
    }
}