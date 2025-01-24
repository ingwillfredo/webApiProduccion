using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProduccion.Entities.Models;

namespace WebApiProduccion.Data.Interfaces
{
    public interface IReviewsRepository
    {
        Task<List<Review>> GetAllReviewsByBook(int id);
        Task<List<Review>> GetAllReviewsByUser(int id);
        Task<bool> AddReview(AddReview review);
        Task<string> UpdateReview(AddReview review);
        Task<string> DeleteReview(int id);
    }
}
