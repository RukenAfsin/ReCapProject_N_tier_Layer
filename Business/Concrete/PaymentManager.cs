using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentdal;
        IRentalService _rentalService;

        public PaymentManager(IPaymentDal paymentdal, IRentalService rentalService)
        {
            _paymentdal = paymentdal;
            _rentalService = rentalService;
        }

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            //IResult result = BusinessRules.Run(IfPaymentSuccess(Rental payment));

          
                _paymentdal.Add(payment);          
                return new SuccessResult(Message.PaymentAdded);
          
        }

        public IDataResult<List<PaymentDetailDto>> GetPaymentsDetail()
        {
            return new SuccessDataResult<List<PaymentDetailDto>>(_paymentdal.GetPaymentsDetails());
        }

        private IResult IfPaymentSuccess( Rental r,Payment p)
        {

            var result = _paymentdal.Add;

            if (result!=null)
            {
                   
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
