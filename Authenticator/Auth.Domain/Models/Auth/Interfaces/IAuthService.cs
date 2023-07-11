using Auth.Domain.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Models.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<responseKeyClockToken?> GetToken(string user, string password);

        Task<object> GetUses();

        Task<object> CreateUser(UserDto user);
    }
}
