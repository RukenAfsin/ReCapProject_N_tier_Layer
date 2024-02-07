
using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<Payment>
    {
        public PaymentValidator() 
        {
            RuleFor(p => p.CVV).GreaterThan(99).LessThanOrEqualTo(999);
            RuleFor(p => p.CardNo).GreaterThan(1000000000000000).LessThanOrEqualTo(9999999999999999);
        }

    }
}
