using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories
{
    public class IUser
    {
        public interface IUsuario
        {
            void NewUser(UserDTO user);
            void UpdateUser(UpdateUserDTO UpdateUser);

            void DeleteUser(int id);
            UserModel GetUserById(int id);
            UserModel GetUserByEmail(string email);
            List<UserModel> GetUserByName(string name);
        }
    }
}
