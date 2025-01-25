using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Data.Repositories;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;

namespace WebApiProduccion.Controllers
{
    [Route("api/Users")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        /// <summary>
        /// VAlida si existe el email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("ValidateEmail/{email}")]
        public async Task<IActionResult> ValidateEmail(string email)
        {
            return Ok(await _usersRepository.ValidateEmail(email));

        }
    }
}
