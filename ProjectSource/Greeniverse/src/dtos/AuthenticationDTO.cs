using System.ComponentModel.DataAnnotations;

namespace Greeniverse.src.dtos
{
    public class AuthenticationDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public AuthenticationDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
