
using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{ 
  /// <summary>
  /// <para>Resume: Class responsible for implement methos CRUD shoppingcart.</para>
  /// <para>Version: 1.0</para>
  /// <para>Date: 05/13/2022</para>
  /// </summary>
    public class ShoppingCartRepository : IShoppingCart
    {

        #region Attribute

        private readonly GreeniverseContext _context;

        #endregion Attribute


        #region Constructor
        public ShoppingCartRepository(GreeniverseContext context)
        {
            _context = context;
        }
        #endregion Constructor


        #region Methods

        /// <summary>
        /// <para>Resume: method for delete existent ShoppingCart.</para>
        /// </summary>
        /// <param name="id">Id of ShoppingCart</param>
        public async Task DeleteShoppingCartAsync(int id)
        {
            _context.ShoppingCart.Remove(await GetShoppingCartByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for get all products of ShoppingCart.</para>
        /// </summary>
        /// <returns>List of ShoppingCartModel</returns>
        public async Task<List<ShoppingCartModel>> GetAllProductsAsync()
        {
            return await _context.ShoppingCart
                .Include(c => c.Purchaser)
                .Include(c => c.Product)
                .ToListAsync();
        }

        /// <summary>
        /// <para>Resume: method for get ShoppingCart by id.</para>
        /// </summary>
        /// <param name="id">Id of ShoppingCart</param>
        /// <returns>ShoppingCartModel</returns>
        public async Task<ShoppingCartModel> GetShoppingCartByIdAsync(int id)
        {
            return await _context.ShoppingCart.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// <para>Resume: method for add new ShoppingCart .</para>
        /// </summary>
        /// <param name="shoppingCart">ShoppingCartDTO</param>
        /// <returns>ShoppingCartModel</returns>
        public async Task NewShoppingCartAsync(NewShoppingCartDTO shoppingCart)
        {
            await _context.ShoppingCart.AddAsync(new ShoppingCartModel
            {
                PaymentMethod = shoppingCart.PaymentMethod,
                Voucher = shoppingCart.Voucher,
                DeliveryAddress = shoppingCart.DeliveryAddress,
                Purchaser = await _context.User.FirstOrDefaultAsync(u => u.Email == shoppingCart.EmailPurchaser),
                Product = await _context.Stock.FirstOrDefaultAsync(s => s.Id == shoppingCart.IdProduct)
            });
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for update existent ShoppingCart.</para>
        /// </summary>
        /// <param name="updateshoppingCart">ShoppingCartDTO</param>
        /// <returns>ShoppingCartModel</returns>
        public async Task UpdateShoppingCartAsync(UpdateShoppingCartDTO updateshoppingCart)
        {
            var CartExistance = await GetShoppingCartByIdAsync(updateshoppingCart.Id);
            CartExistance.PaymentMethod = updateshoppingCart.PaymentMethod;
            CartExistance.Voucher = updateshoppingCart.Voucher;
            CartExistance.DeliveryAddress = updateshoppingCart.DeliveryAddress;
            _context.ShoppingCart.Update(CartExistance);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartModel>> GetAllProductsByEmailPurchaserAsync(string emailPurchaser)
        {
            return await _context.ShoppingCart
               .Include(c => c.Purchaser)
               .Include(c => c.Product)
               .Where(c => c.Purchaser.Email == emailPurchaser)
               .ToListAsync();
        }
        #endregion

    }
}