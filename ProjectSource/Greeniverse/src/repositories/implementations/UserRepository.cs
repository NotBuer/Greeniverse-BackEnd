using Greeniverse.src.data;
using Greeniverse.src.DTOS;
using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    /// <summary>
    /// <para>Resume: Class responsible for implement methos CRUD Users.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
    /// </summary>
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

        /// <summary>
        /// <para>Resume: method for add a new user.</para>
        /// </summary>
        /// <param name="user">UserRegisterDTO</param>
        public async Task NewUserAsync (NewUserDTO user)
        {
            await _context.User.AddAsync(new UserModel
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Telephone = user.Telephone,
                UserType = user.UserType,
                WalletCoins = user.WalletCoins
            });
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for update am existent user.</para>
        /// </summary>
        /// <param name="user">UserUpdateDTO</param>
        public async  Task UpdateUserAsync (UpdateUserDTO user)
        {
            UserModel existingUser = await GetUserByIdAsync(user.Id);
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.Address = user.Address;
            existingUser.Telephone = user.Telephone;
            existingUser.WalletCoins = user.WalletCoins;
            _context.User.Update(existingUser);
           await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for delete a existent user.</para>
        /// </summary>
        /// <param name="id">Id of user</param>
        public async Task DeleteUserAsync (int id)
        {
          _context.User.Remove(await GetUserByIdAsync(id));
          await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for get user by email.</para>
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <returns>UserModel</returns>
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(user => user.Email == email);
        }

        /// <summary>
        /// <para>Resume:method for get user by id.</para>
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>UserModel</returns>
        public async Task<UserModel> GetUserByIdAsync (int id )
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// <para>Resume: method for get user by name.</para>
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <returns>List of UserModel</returns>
        public async Task<List<UserModel>> GetUserByNameAsync(string name)
        {
            return await _context.User
                .Where(u => u.Name==name)
                .ToListAsync();               
        }
        #endregion

    }

}
