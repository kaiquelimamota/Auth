using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Models.Auth
{
    public class responseKeyClockToken
    {
        public string access_token { get; set; } = string.Empty;
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        public string refresh_token { get; set; } = string.Empty;
        public string token_type { get; set; } = string.Empty;
        public string session_state { get; set; } = string.Empty;
        public string scope { get; set; } = string.Empty;
    }
}
