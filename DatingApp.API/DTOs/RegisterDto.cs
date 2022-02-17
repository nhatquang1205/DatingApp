using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(32)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}