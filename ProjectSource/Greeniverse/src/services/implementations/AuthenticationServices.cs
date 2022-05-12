using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using Greeniverse.src.repositories.implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Greeniverse.src.services.implementations
{   
    public class AuthenticationServices : IAuthentication
    {

        #region Atributte

        private readonly IUser _repository;
        public IConfiguration Configuration { get; }

        #endregion


        #region Constructor

        public AuthenticationServices(IUser repository, IConfiguration configuration)
        {
            _repository = repository;
            Configuration = configuration;
        }

        #endregion

        #region Methods

        public string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public string GenerateToken(UserModel user)
        {
            var tokenManipulator = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
            new Claim[]
            {
            new Claim(ClaimTypes.Email, user.Email.ToString()),
            new Claim(ClaimTypes.Role, user.UserType.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
            )
            };
            var token = tokenManipulator.CreateToken(tokenDescription);
            return tokenManipulator.WriteToken(token);

        }
        public async Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication)
        {
<<<<<<< HEAD
            var user = _repository.GetUserByEmailAsync(authentication.Email);
=======
            var user = await _repository.GetUserByEmailAsync(authentication.Email);

>>>>>>> 89007d78768a4e816a61ef7c2ba4ddd7ed3e1b99
            if (user == null) throw new Exception("Usuário não encontrado");

            if (user.Password != EncodePassword(authentication.Password)) throw new Exception("Senha incorreta");

            return new AuthorizationDTO(user.Id, user.Email, user.UserType,GenerateToken(user));

        }

        public async Task CreateUserWithoutDuplicateAsync(NewUserDTO userDTO)
        {
<<<<<<< HEAD
            var userObject = _repository.GetUserByEmailAsync(userDTO.Email);
=======
            var userObject = await _repository.GetUserByEmailAsync(userDTO.Email);

>>>>>>> 89007d78768a4e816a61ef7c2ba4ddd7ed3e1b99
            if (userObject != null) throw new Exception("Este email já está sendo utilizado");

            userDTO.Password = EncodePassword(userDTO.Password);

           await _repository.NewUserAsync(userDTO);
        }

        #endregion

    }
}
