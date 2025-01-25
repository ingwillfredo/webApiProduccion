using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiProduccion.Data.Interfaces;
using WebApiProduccion.Data.Repositories;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;

namespace WebApiProduccion.Controllers
{
    [Route("api/Reviews")]
    [Authorize]
    [ApiController]

    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepository _reviewsRepository;

        public ReviewsController(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }

        /// <summary>
        /// Obtiene las reseñas por libro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllReviewsByBook/{id}")]
        public async Task<IActionResult> GetAllReviewsByBook(int id)
        {
            return Ok(await _reviewsRepository.GetAllReviewsByBook(id));
        }



        [HttpGet("GetAllReviewsByUser/{id}")]
        public async Task<IActionResult> GetAllReviewsByUser(int id)
        {
            return Ok(await _reviewsRepository.GetAllReviewsByUser(id));
        }


        /// <summary>
        /// Agrega reseña
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview(AddReview review)
        {
            return Ok(await _reviewsRepository.AddReview(review));
        }

        /// <summary>
        /// Actualiza reseña
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReview(AddReview review)
        {
            return Ok(await _reviewsRepository.UpdateReview(review));
        }



        [HttpDelete("DeleteReview/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            return Ok(await _reviewsRepository.DeleteReview(id));
        }
    }
}
