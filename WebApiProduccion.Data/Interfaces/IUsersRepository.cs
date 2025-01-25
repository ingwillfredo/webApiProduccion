using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProduccion.Entities;
using WebApiProduccion.Entities.Models;

namespace WebApiProduccion.Data.Interfaces
{
    public interface IUsersRepository
    {
        Task<string> AddUser(AddUser user);
        Task<LoginUser> LoginUser(Login user);
        Task<bool> ValidateEmail(string email);
    }
}
