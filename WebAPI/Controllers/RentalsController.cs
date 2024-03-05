using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetRentalsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("checkrentalcarid")] //araç müsait mi değil mi 
        public IActionResult CheckRentalCarId(int carId)
        {
            var result = _rentalService.CheckRentalCarId(carId);

            return Ok(result);
        }


        [HttpPost("checkrental")] //directed to payment page
        public IActionResult CheckRental(Rental entity)
        {
            var result = _rentalService.CheckRental(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcustomer")]
        public IActionResult GetCustomer(int customerId)
        {
            var result = _rentalService.GetRentalsByCustomerId(customerId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getrentals")]
        public IActionResult GetRentalsByCar(int carId)
        {
            var result = _rentalService.GetRentalsByCarId(carId);
            if( result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("getrentalsbycarId")]
        public IActionResult GetRentalsByCarId(int id)
        {
            var result = _rentalService.GetRentalsByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}