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
        public AuthorizationDTO GetAuthorization(AuthenticationDTO authentication)
        {
            var user = _repository.GetUserByEmailAsync(authentication.Email);
            if (user == null) throw new Exception("Usuário não encontrado");
            if (user.Password != EncodePassword(authentication.Password)) throw new
            Exception("Senha incorreta");
            return new AuthorizationDTO(user.Id, user.Email, user.UserType,GenerateToken(user));

        }

        public void CreateUserWithoutDuplicate(NewUserDTO userDTO)
        {
            var userObject = _repository.GetUserByEmailAsync(userDTO.Email);
            if (userObject != null) throw new Exception("Este email já está sendo utilizado");
            userDTO.Password = EncodePassword(userDTO.Password);
            _repository.NewUser(userDTO);
        }

        #endregion

    }
}
