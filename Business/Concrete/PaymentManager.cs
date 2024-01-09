using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
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
            //IResult result = BusinessRules.Run(IfPaymentSuccess());

            //if (result != null && result.Success)
            //{
                _paymentdal.Add(payment);
               /* _rentalService.Add(new Rental()); */// Burada uygun bir Rental nesnesi oluşturmanız gerekiyor.
                return new SuccessResult(Message.PaymentAdded);
            //}
            //return new ErrorResult();
        }

        //private IResult IfPaymentSuccess()
        //{
           
        //    bool paymentSuccess = true; // Bu kısmı kendi iş mantığınıza göre güncelleyin.

        //    if (paymentSuccess)
        //    {
        //        return new SuccessResult();
        //    }

        //    return new ErrorResult();
        //}
    }
}
