using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Threading.Tasks;

namespace Greeniverse.src.services
{
    /// <summary>
    /// <para>Resume: Interface responsible for authentication logic.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>
    
    public interface IAuthentication
    {
        string EncodePassword (string password);
        Task CreateUserWithoutDuplicateAsync(NewUserDTO user);
        string GenerateToken(UserModel user);
        Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication);
    }
}
