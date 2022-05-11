<<<<<<< HEAD
﻿namespace Greeniverse.src.dtos{    public class AuthenticationDTO    {    }}
=======
﻿using System.ComponentModel.DataAnnotations;

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
>>>>>>> fc74dd963581509c51fa502658772a0aa7647f97
