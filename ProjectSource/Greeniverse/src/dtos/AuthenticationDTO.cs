using Greeniverse.src.utils;
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
    public class AuthorizationDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public string Token { get; set;  }

        public AuthorizationDTO(int id, string email, UserType type, string token)
        {
            Id = id;
            Email = email;
            Type = type;
            Token = token;
        }
    }
}