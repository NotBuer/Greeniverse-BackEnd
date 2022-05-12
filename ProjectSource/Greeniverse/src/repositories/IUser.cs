using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    public interface IUser
    {
        void NewUser(NewUserDTO user);
        void UpdateUser(UpdateUserDTO user);
        void DeleteUser(int id);
        UserModel GetUserByIdAsync(int id);
        UserModel GetUserByEmailAsync(string email);
        List<UserModel> GetUserByName(string name);
        Task GetUserByNameAsync(string nameUser);
        Task UpdateUserAsync(UpdateUserDTO user);
        Task DeleteUserAsync(int idUser);
    }
}
