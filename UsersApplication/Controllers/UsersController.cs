using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApplication.Models;
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
        public async Task<IActionResult> Get(int idUser)
        {
            try
            {
                var result = await usersServices.Seek(idUser);

                return Ok(result);
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.StatusCode, ex.Error);
            }

        }
    }
}
