using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    /// <summary>
    /// <para>Abstract:Responsible for representing user CRUD actions</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>
    public interface IUser
    {   
        Task NewUserAsync(NewUserDTO user);
        Task UpdateUserAsync(UpdateUserDTO user);
        Task DeleteUserAsync(int id);
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<List<UserModel>> GetUserByNameAsync(string name);

    }
}
