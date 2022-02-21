using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }     
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string KnownAs { get ;set; }
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string Avatar { get; set; }
        public string City { get; set; }
    }
}