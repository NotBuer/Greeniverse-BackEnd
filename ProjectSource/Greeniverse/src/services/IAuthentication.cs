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
        Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication);
    }
}
