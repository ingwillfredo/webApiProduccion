using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiProduccion.Data.Interfaces;

namespace WebApiProduccion.Controllers
{
    [Route("api/Books")]
    [Authorize]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksrepository _booksRepository;

        public BooksController(IBooksrepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _booksRepository.GetAllBooks());
        }


        /// <summary>
        /// Obtiene libro por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetBookById/{Id}")]
        public async Task<IActionResult> GetBookById(int Id)
        {
            return Ok(await _booksRepository.GetBookById(Id));
        }
    }
}
