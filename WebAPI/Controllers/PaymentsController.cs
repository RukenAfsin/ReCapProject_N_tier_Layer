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

        [HttpPost("add")]

        public IActionResult PaymentAdd(Payment payment)
        {
            var result= _paymentservice.Add(payment);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet("paymentdetail")]
        public IActionResult GetDetail() 
        {
            var result = _paymentservice.GetPaymentsDetail();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
          
          
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
