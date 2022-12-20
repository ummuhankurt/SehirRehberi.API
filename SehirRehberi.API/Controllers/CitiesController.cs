using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.DataAccess.Abrtract;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityDal _cityDal { get; set; }
        private IMapper _mapper { get; set; }
        public CitiesController(ICityDal cityDal,IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cityDal.GetAll();
            return Ok(result);
        }
        [HttpGet("details")]
        public IActionResult GetDetails()
        {
            var result = _cityDal.GetCitiesDetails();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(result);
            return Ok(citiesToReturn);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cityDal.GetCitiesDetailsById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(result);
            return Ok(cityToReturn);
        }
        [HttpPost("add")]
        public IActionResult Add(City city)
        {
            _cityDal.Add(city);
            return Ok();
        }
    }
}
