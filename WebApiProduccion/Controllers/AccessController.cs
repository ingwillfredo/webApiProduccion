using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProduccion.Data.Data;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Data.Repositories;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;

namespace WebApiProduccion.Controllers
{
    [Route("api/Access")]
    [AllowAnonymous]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IBooksrepository _booksRepository;
        private readonly IReviewsRepository _reviewsRepository;

        public AccessController(IUsersRepository user, IBooksrepository booksrepository, IReviewsRepository reviewsRepository)
        {
            _usersRepository = user;
            _booksRepository = booksrepository;
            _reviewsRepository = reviewsRepository; 
        }

        /// <summary>
        /// Login usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(Login user)
        {
            return Ok(await _usersRepository.LoginUser(user));
        }


        /// <summary>
        /// Registro usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUser user)
        {
            return Ok(await _usersRepository.AddUser(user));
        }


        /// <summary>
        /// Valida si existe Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("ValidateEmail/{email}")]
        public async Task<IActionResult> ValidateEmail(string email)
        {
            return Ok(await _usersRepository.ValidateEmail(email));

        }


        /// <summary>
        /// obtiene libros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _booksRepository.GetAllBooks());
        }


        /// <summary>
        /// Obtiene libro por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetBookById/{Id}")]
        public async Task<IActionResult> GetBookById(int Id)
        {
            return Ok(await _booksRepository.GetBookById(Id));
        }


        /// <summary>
        /// Obtiene la reseñas por lbro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllReviewsByBook/{id}")]
        public async Task<IActionResult> GetAllReviewsByBook(int id)
        {
            return Ok(await _reviewsRepository.GetAllReviewsByBook(id));
        }
    }
}
