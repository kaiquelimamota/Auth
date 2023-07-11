using Auth.Domain.Models.Auth;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Modules.Auth.Interfaces;

[Headers("Content-Type:application/x-www-form-urlencoded;charset=UTF-8")]
public interface IkeyCloackApi
{
    [Post("/Realm1/protocol/openid-connect/token")]
    Task<responseKeyClockToken> GetToken([Body(BodySerializationMethod.UrlEncoded)] GetTokenModel getTokenModel);

    [Get("/Realm1/users")]
    Task<object> GetUsers();
}
