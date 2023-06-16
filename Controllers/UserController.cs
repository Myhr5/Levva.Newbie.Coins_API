using Levva.Newbie.Coins.Logic.Dtos;
using Levva.Newbie.Coins.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbie.Coins.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserDto> Create(UserDto user)
        {
            _service.Create(user);
            return Created("", user);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int Id)
        {
            return _service.Get(Id);
        }

        [HttpGet("list")]
        public ActionResult<List<UserDto>> GetAll(int Id)
        {
            return _service.GetAll();
        }

        [HttpPut("{id}")]
        public IActionResult Update(UserDto user)
        {
            _service.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return Ok();
        }
        [HttpPost("auth")]
        [AllowAnonymous]
        public ActionResult<LoginDto> Login(LoginDto loginDto)
        {
            var login = _service.Login(loginDto);
            if (login == null)
                return BadRequest("Usuário ou senha inválidos");
            return Ok(login);
        }
    }
}
