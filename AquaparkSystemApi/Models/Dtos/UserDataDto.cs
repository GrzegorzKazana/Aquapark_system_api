using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AquaparkSystemApi.Models.Dtos
{
    public class UserDataDto
    {
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Surname { get; set; }
    }
}