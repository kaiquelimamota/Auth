using Auth.Application.Modules.Auth.Interfaces;
using Auth.Domain.Dtos.Auth;
using Auth.Domain.Models.Auth;
using Auth.Domain.Models.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Modules.Auth.Services;

public class AuthService: IAuthService
{
    private readonly IkeyCloackApi _keyCloackApi;
    private readonly IkeyCloackApiUser _keyCloackApiUser;

    public AuthService(IkeyCloackApi keyCloackApi, IkeyCloackApiUser keyCloackApiUser) 
    {
        _keyCloackApi = keyCloackApi;
        _keyCloackApiUser = keyCloackApiUser;
    }

    public async Task<responseKeyClockToken?> GetToken(string user, string password)
    {
        var body = new GetTokenModel()
        {
            client_id = "Api-Teste",
            client_secret = "QhirNAwGsfwVNf5gCmEI9BArUovlQZLL",
            grant_type = "password",
            password = password,
            username = user
        };

        return await _keyCloackApi.GetToken(body);
    }

    public async Task<object> GetUses()
    {
        return await _keyCloackApi.GetUsers();
    }

    public async Task<object> CreateUser(UserDto user)
    {
        

        return await _keyCloackApiUser.CreateUser(user, "");
    }

}
