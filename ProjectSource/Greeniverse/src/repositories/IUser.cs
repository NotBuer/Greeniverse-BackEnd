using Greeniverse.src.models;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Greeniverse.src.repositories.implementations
{
    public interface IUser
    {
        void NewUser(NewUserDTO user);
        void UpdateUser(UpdateUserDTO user);
        void DeleteUser(int id);
        UserModel GetUserById(int id);
        UserModel GetUserByEmail(string email);
        List<UserModel> GetUserByName(string name);
    }
}
