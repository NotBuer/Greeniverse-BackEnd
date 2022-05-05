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

        }

        public void DeleteUser(int id)
        {
          _context.User.Remove(GetUserById(id));
          _context.SaveChanges();
        }

        public UserModel GetUserByEmail(string email)
        {
            // TODO: Need implementation.
            return null;
        }

        public UserModel GetUserById(int id)
        {
            // TODO: Need implementation.
            return null;
        }

        public List<UserModel> GetUserByName(string name)
        {
            return _context.User.Where(u => u.Name==name).ToList();
            
            
        }
        #endregion

    }

}
