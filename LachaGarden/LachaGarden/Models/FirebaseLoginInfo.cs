﻿using DataAccessLayer.Models;

namespace LachaGarden.Models
{
    public class FireBaseLoginInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; } = true;
        public bool RoleName { get; set; } = true;
    }
}