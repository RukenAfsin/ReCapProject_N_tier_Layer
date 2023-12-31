﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =_carService.GetAll();

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetAll();

            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result =_carService.Add(car);
            if (result.Success)
            {
                return Ok(result.Success);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result=_carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcardtodetails")]
        public IActionResult GetDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetCarByBrand(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("getbycolor")]
        public IActionResult GetCarByColor(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcarbycolorandbrand")]
        public IActionResult GetCarByColorAndBrand(int colorId, int brandId)
        {
            var result =_carService.GetCarDetailByColorAndBrand(colorId, brandId);
            if( result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(("hata varrrr"));
        }
    }
}
