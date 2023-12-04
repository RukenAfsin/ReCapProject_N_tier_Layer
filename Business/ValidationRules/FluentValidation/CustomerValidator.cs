﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
                RuleFor(p=>p.CompanyName).NotEmpty().MinimumLength(2);
        }
    }
}
