using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentservice;

        public PaymentsController(IPaymentService paymentservice)
        {
            _paymentservice = paymentservice;
        }

        [HttpPost]

        public IActionResult PaymentAdd(Payment payment)
        {
            var result= _paymentservice.Add(payment);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
