using FastStart.Models;
using FastStart.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastStart.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "AtLeast18")]
        public ActionResult<IEnumerable<UsersDTO>> GetAll([FromQuery]string searchPhrase)
        {
            var usersDTOs = _userService.GetAll(searchPhrase);

            return Ok(usersDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<UsersDTO> Get([FromRoute] int id)
        {
            var users = _userService.GetById(id);
        
            return Ok(users);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateUsersDTO dto)
        {
            var id = _userService.Create(dto);

            return Created($"/api/users/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateUsersDTO dto, [FromRoute] int id)
        {
            _userService.Update(id, dto);
            
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete([FromRoute] int id)
        {
            _userService.Delete(id);

            return NoContent();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody]LoginDTO dto)
        {
            string token = _userService.GenerateJwt(dto);
            return Ok(token);
        }

    }
}
