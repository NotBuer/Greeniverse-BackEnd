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
    /// <summary>
    /// <para>Resumo: Class responsible for implementation IAutenticacao</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 05/13/2022</para>
    /// </summary>
    
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

        /// <summary>
        /// <para>Resumo: Method responsible for encrypting password</para>
        /// </summary>
        /// <param name="password">Senha a ser criptografada</param>
        /// <returns>string</returns>
        
        public string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// <para>Resumo: Method responsible for generating JWT token</para> 
        /// </summary>
        /// <param name="user">UsuarioModelo</param>
        /// <returns>string</returns>

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

        /// <summary>
        /// <para>Resumo: Responsible method return authorization to authenticated user</para>
        /// </summary>
        /// <param name="authentication">AutenticarDTO</param>
        /// <returns>AutorizacaoDTO</returns>
        /// <exception cref="Exception">Usuário não encontrado</exception>
        /// <exception cref="Exception">Senha incorreta</exception>

        public async Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication)
        {
            var user = await _repository.GetUserByEmailAsync(authentication.Email);


            if (user == null) throw new Exception("Usuário não encontrado");

            if (user.Password != EncodePassword(authentication.Password)) throw new Exception("Senha incorreta");

            return new AuthorizationDTO(user.Id, user.Email, user.UserType,GenerateToken(user));

        }

        /// <summary>
        /// <para>Resumo: Method responsible for creating user without duplicating in the bank</para>
        /// </summary>
        /// <param name="userDTO">NovoUsuarioDTO</param>

        public async Task CreateUserWithoutDuplicateAsync(NewUserDTO userDTO)
        {
            var user = await _repository.GetUserByEmailAsync(userDTO.Email);

            if (user != null) throw new Exception("Este email já está sendo utilizado");

            userDTO.Password = EncodePassword(userDTO.Password);

           await _repository.NewUserAsync(userDTO);
        }

        #endregion

    }
}
