using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(3000);
            var result = _brandService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();    
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result= _brandService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result =_brandService.Add(brand);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getdetailsbrand")]
        public IActionResult GetBrand()
        {
            var result= _brandService.GetBrandDetails();
            if( result.Success )
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
