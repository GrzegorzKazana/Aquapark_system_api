﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class UserLoggedOutDto
    {
        public bool Success { get; set; }
        public string Status { get; set; }
    }
}