using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProduccion.Entities;

namespace WebApiProduccion.Data.Interfaces
{
    public interface IBooksrepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int Id);
    }
}
