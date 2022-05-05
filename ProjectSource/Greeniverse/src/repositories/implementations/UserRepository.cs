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
            _context.User.Add(new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Telephone = user.Phone,
                UserType = user.UserType
            });
            _context.SaveChanges();
        }

        public void UpdateUser(UpdateUserDTO user)
        {

        }

        public void DeleteUser(int id)
        {
            
        }

        public UserModel GetUserByEmail(string email)
        {
            return _context.User.FirstOrDefault(user => user.Email == email);
        }

        public UserModel GetUserById(int id)
        {
            // TODO: Need implementation.
            return null;
        }

        public List<UserModel> GetUserByName(string name)
        {
            // TODO: Need implementation.
            return null;
        }
        #endregion

    }

}
