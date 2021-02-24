using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Model
{
    public class TokenApiModel
    {
        public string AccessToken { get; internal set; }
        public string RefreshToken { get; internal set; }
    }
}
