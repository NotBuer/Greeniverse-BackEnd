using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Threading.Tasks;

namespace Greeniverse.src.services
{
    public interface IAuthentication
    {
        string EncodePassword (string password);
        Task CreateUserWithoutDuplicateAsync(NewUserDTO user);
        string GenerateToken(UserModel user);
<<<<<<< HEAD:ProjectSource/Greeniverse/src/services/implementations/IAuthentication.cs
        AuthorizationDTO GetAuthorization(AuthenticationDTO authentication);
        Task CreateUserWithoutDuplicateAsync(NewUserDTO user);
=======
        Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication);
>>>>>>> 89007d78768a4e816a61ef7c2ba4ddd7ed3e1b99:ProjectSource/Greeniverse/src/services/IAuthentication.cs
    }
}
