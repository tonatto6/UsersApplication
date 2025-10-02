using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApplication.Models;
using UsersApplication.Models.Users;
using UsersApplication.Services.Interfaces;

namespace UsersApplication.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices usersServices;

        public UsersController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        [HttpGet("{idUser}")]
        [Authorize]
        public async Task<IActionResult> Get(int idUser)
        {
            try
            {
                var result = await usersServices.Seek(idUser);

                return Ok(new Response(200, false, result));
            }
            catch (CustomException ex)
            {
                var response = new Response(ex.StatusCode, true, ex.Error);
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Insert([FromBody]UserInsertRequest user)
        {
            try
            {
                var result = await usersServices.Insert(user);

                return Ok(new Response(200, false, result));
            }
            catch (CustomException ex)
            {
                var response = new Response(ex.StatusCode, true, ex.Error);
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginRequest user)
        {
            try
            {
                var result = await usersServices.ValidatePassword(user);

                return Ok(new Response(200,false,result));
            }
            catch (CustomException ex)
            {
                var response = new Response(ex.StatusCode, true, ex.Error);
                return StatusCode(response.StatusCode, response);
            }
        }
    }
}
