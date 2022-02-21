using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Database.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Username { get; set; }     
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(255)]
        public string KnownAs { get ;set; }
        [StringLength(16)]
        public string Gender { get; set; }
        [StringLength(255)]
        public string Introduction { get; set; }
        [StringLength(512)]
        public string Avatar { get; set; }
        [StringLength(32)]
        public string City { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}