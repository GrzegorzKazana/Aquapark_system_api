using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.PassedParameters
{
    public class ZoneEntry
    {
        public string UserToken { get; set; }
        public string Email { get; set; }
        public int ZoneId { get; set; }
    }
}