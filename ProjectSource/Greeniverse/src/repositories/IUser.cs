using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
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
