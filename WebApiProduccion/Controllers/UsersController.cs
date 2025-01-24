using Microsoft.AspNetCore.Mvc;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Data.Repositories;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;

namespace WebApiProduccion.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// Agrega nuevoo usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUser user)
        {
            return Ok(await _usersRepository.AddUser(user));
        }


        /// <summary>
        /// VAlida el login del usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUser user)
        {
            bool IsMatch = await _usersRepository.LoginUser(user);
            return Ok(IsMatch);
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
