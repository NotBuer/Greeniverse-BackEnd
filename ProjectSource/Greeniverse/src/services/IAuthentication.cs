using Greeniverse.src.dtos;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Threading.Tasks;

namespace Greeniverse.src.services
{
    /// <summary>
<<<<<<< HEAD
    /// <para>Resume: Interface Responsible for representing authentication actions</para>
    /// <para>Version: 1.0</para>
    /// <para>Data: 2022-05-03</para>
=======
    /// <para>Resume: Interface responsible for authentication logic.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 2022-13-05</para>
>>>>>>> 79e9ab0a909f578d28fbafae1538c056798228e9
    /// </summary>
    public interface IAuthentication
    {
        string EncodePassword (string password);

        Task CreateUserWithoutDuplicateAsync(NewUserDTO user);

        string GenerateToken(UserModel user);
<<<<<<< HEAD
        Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication);
=======

        AuthorizationDTO GetAuthorization(AuthenticationDTO authentication);

        Task<AuthorizationDTO> GetAuthorizationAsync(AuthenticationDTO authentication);

>>>>>>> 79e9ab0a909f578d28fbafae1538c056798228e9
    }
}
