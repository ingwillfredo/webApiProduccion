using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProduccion.Entities;

namespace WebApiProduccion.Data.Interfaces
{
    public interface IUsersRepository
    {
        Task<string> AddUser(AddUser user);
        Task<bool> LoginUser(LoginUser user);
        Task<bool> ValidateEmail(string email);
    }
}
