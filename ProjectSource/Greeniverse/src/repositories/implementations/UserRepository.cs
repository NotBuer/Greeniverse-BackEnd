using Greeniverse.src.data;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Linq;

namespace Greeniverse.src.repositories.implementations
{

    public class UserRepository : IUser
    {

        #region Attribute

        private readonly GreeniverseContext _context;

        #endregion


        #region Constructor
        public UserRepository(GreeniverseContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
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
            UserModel existingUser = GetUserById(user.Id);
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Address = user.Address;
            existingUser.Telephone = user.Phone;
            _context.User.Update(existingUser);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
          _context.User.Remove(GetUserById(id));
          _context.SaveChanges();
        }

        public UserModel GetUserByEmail(string email)
        {
            return _context.User.FirstOrDefault(user => user.Email == email);
        }

        public UserModel GetUserById(int id)
        {
            return _context.User.FirstOrDefault(u => u.Id == id);
        }

        public List<UserModel> GetUserByName(string name)
        {
            return _context.User.Where(u => u.Name==name).ToList();
            
            
        }
        #endregion

    }

}
