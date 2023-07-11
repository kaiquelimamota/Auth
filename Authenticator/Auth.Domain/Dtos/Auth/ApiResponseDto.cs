using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Dtos.Auth;

public class ApiResponseDto
{
    public string Data { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string MessageError { get; set; } = string.Empty;
    public bool Success { get; set; } = true;

}
