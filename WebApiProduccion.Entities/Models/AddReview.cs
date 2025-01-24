using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProduccion.Entities.Models
{
    public class AddReview
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public int Id_Book { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
