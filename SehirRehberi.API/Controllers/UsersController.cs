using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.DataAccess.Abrtract;
using SehirRehberi.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserDal _userDal { get; set; }
        public UsersController(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userDal.GetAll();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userDal.Get(c => c.Id == id);
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            _userDal.Add(user);
            return Ok();
        }
    }
}
