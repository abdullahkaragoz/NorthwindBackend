﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Core.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
