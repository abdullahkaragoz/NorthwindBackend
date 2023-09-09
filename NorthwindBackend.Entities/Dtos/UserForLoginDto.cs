using NorthwindBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
