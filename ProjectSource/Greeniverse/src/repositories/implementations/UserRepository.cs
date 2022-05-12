using Greeniverse.src.data;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task NewUserAsync (NewUserDTO user)
        {
            await _context.User.AddAsync(new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Telephone = user.Phone,
                UserType = user.UserType
            });
            await _context.SaveChangesAsync();
        }

        public async  Task UpdateUserAsync (UpdateUserDTO user)
        {
            UserModel existingUser = await GetUserByIdAsync(user.Id);
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Address = user.Address;
            existingUser.Telephone = user.Phone;
            _context.User.Update(existingUser);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync (int id)
        {
          _context.User.Remove( await GetUserByIdAsync(id));
           await _context.SaveChangesAsync();
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(user => user.Email == email);
        }

        public  async Task<UserModel> GetUserByIdAsync (int id )
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<UserModel>> GetUserByNameAsync(string name)
        {
            return await _context.User
                .Where(u => u.Name==name)
                .ToListAsync();
            
            
        }
        #endregion

    }

}
