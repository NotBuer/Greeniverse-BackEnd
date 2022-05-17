using Greeniverse.src.utils;
using System.ComponentModel.DataAnnotations;

namespace Greeniverse.src.dtos
{
    /// <summary>
    /// <para>Resumo: Mirror class to authenticate a user</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/13/2022</para>
    /// </summary>
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
    /// <summary>
    /// <para>Resumo: Mirror class to represent a user's authorization</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/13/2022</para>
    /// </summary>
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
