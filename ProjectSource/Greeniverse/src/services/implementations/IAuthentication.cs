using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Threading.Tasks;

namespace Greeniverse.src.services
{
    public interface IAuthentication
    {
        string EncodePassword (string password);
        void CreateUserWithoutDuplicate(NewUserDTO user);
        string GenerateToken(UserModel user);
        AuthorizationDTO GetAuthorization(AuthenticationDTO authentication);
        Task CreateUserWithoutDuplicateAsync(NewUserDTO user);
    }
}
