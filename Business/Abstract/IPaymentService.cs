﻿using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
        IDataResult<List<PaymentDetailDto>> GetPaymentsDetail();
        IDataResult<List<Payment>> GetAll();

    }
}
