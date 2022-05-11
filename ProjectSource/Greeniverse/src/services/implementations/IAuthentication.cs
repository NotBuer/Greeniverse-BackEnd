using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;

namespace Greeniverse.src.services
{
    public interface IAuthentication
    {
        string EncodePassword (string password);
        void CreateUserWithoutDuplicate(NewUserDTO user);
        string GenerateToken(UserModel user);
        AuthorizationDTO GetAuthorization(AuthenticationDTO authentication);
    }
}
