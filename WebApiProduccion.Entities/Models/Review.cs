using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiProduccion.Entities.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name_User { get; set; }
        public string Title_Book { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Date { get; set; }
    }
}
