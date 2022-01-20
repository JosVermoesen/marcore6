using System;
using System.ComponentModel.DataAnnotations;

namespace marcore.api.Dtos.User
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(36, MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string KnownAs { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string BerNumber { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string ClientNumber { get; set; }
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
            // Demo client is set automatically
            // Admin should check the new user first
            ClientNumber = "220750"; 
        }
    }
}
