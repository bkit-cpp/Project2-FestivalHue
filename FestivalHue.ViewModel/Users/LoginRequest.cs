﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.ViewModel.Users
{
    public class LoginRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
