<<<<<<< HEAD
﻿using Greeniverse.src.utils;
using System.ComponentModel.DataAnnotations;
=======
<<<<<<< HEAD
﻿namespace Greeniverse.src.dtos{    public class AuthenticationDTO    {    }}
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 49b4911a1f5ac6df340c6c4298b718cd6e42e93e

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
<<<<<<< HEAD
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
=======
}
>>>>>>> fc74dd963581509c51fa502658772a0aa7647f97
>>>>>>> 49b4911a1f5ac6df340c6c4298b718cd6e42e93e
