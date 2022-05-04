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
=======

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
>>>>>>> d2bbdc45a6f1179373fa6b582320c62129c0111d
    }
}
