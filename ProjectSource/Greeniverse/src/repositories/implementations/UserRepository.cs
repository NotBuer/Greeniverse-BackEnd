using Greeniverse.src.data;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Linq;

namespace Greeniverse.src.repositories.implementations
{

    public class UserRepository : IUser
    {

        #region ATTRIBUTES
        private readonly GreeniverseContext _context;
        #endregion

        
        #region CONSTRUCTORS
        public UserRepository(GreeniverseContext context)
        {
            _context = context;
        }
        #endregion


        #region METHODS
        public void NewUser(NewUserDTO user)
        {

        }

        public void UpdateUser(UpdateUserDTO user)
        {
            UserModel existingUser = GetUserById(user.Id);
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Address = user.Adress;
            existingUser.Telephone = user.Phone;
            _context.User.Update(existingUser);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            
        }

        public UserModel GetUserByEmail(string email)
        {
            // TODO: Need implementation.
            return null;
        }

        public UserModel GetUserById(int id)
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }

        public List<UserModel> GetUserByName(string name)
        {
            // TODO: Need implementation.
            return null;
        }
        #endregion

    }

}
