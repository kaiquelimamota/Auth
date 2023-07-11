using Auth.Domain.Dtos.Auth;
using Auth.Domain.Models.Auth;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Modules.Auth.Interfaces;

[Headers("Content-Type:application/x-www-form-urlencoded;charset=UTF-8")]
public interface IkeyCloackApiUser
{
    [Post("/Realm1/users")]
    Task<object> CreateUser([Body(BodySerializationMethod.UrlEncoded)] UserDto user, [Header("Authorization")] string authorization);
}
