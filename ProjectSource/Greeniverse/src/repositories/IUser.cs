using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    public interface IUser
    {
<<<<<<< HEAD
        void NewUser(NewUserDTO user);
        void UpdateUser(UpdateUserDTO user);
        void DeleteUser(int id);
        UserModel GetUserByIdAsync(int id);
        UserModel GetUserByEmailAsync(string email);
        List<UserModel> GetUserByName(string name);
        Task GetUserByNameAsync(string nameUser);
        Task UpdateUserAsync(UpdateUserDTO user);
        Task DeleteUserAsync(int idUser);
=======
        Task NewUserAsync(NewUserDTO user);
        Task UpdateUserAsync(UpdateUserDTO user);
        Task DeleteUserAsync(int id);
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<List<UserModel>> GetUserByNameAsync(string name);
>>>>>>> 89007d78768a4e816a61ef7c2ba4ddd7ed3e1b99
    }
}
