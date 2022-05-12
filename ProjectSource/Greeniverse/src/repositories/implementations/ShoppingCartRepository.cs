
using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
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
        public async Task DeleteShoppingCartAsync(int id)
        {
            _context.ShoppingCart.Remove(await GetShoppingCartByIdAsync(id));
            await _context.SaveChangesAsync();
        }
﻿
        public async Task<List<ShoppingCartModel>> GetAllProductsAsync()
        {
            return await _context.ShoppingCart.ToListAsync();
        }

        public async Task<ShoppingCartModel> GetShoppingCartByIdAsync(int id)
        {
            return await _context.ShoppingCart.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task NewShoppingCartAsync(NewShoppingCartDTO ShoppingCart)
        {
            await _context.ShoppingCart.AddAsync(new ShoppingCartModel
            {
                AmountProduct = ShoppingCart.AmountProduct,
                PaymentMethod = ShoppingCart.PaymentMethod,
                Voucher = ShoppingCart.Voucher,
                DeliveryAddress = ShoppingCart.DeliveryAdress,
            });
            await _context.SaveChangesAsync();
        }
        public async Task UpdateShoppingCartAsync(UpdateShoppingCartDTO updateshoppingCart)
        {
            var CartExistance = await GetShoppingCartByIdAsync(updateshoppingCart.Id);
            CartExistance.AmountProduct = updateshoppingCart.AmountProduct;
            CartExistance.PaymentMethod = updateshoppingCart.PaymentMethod;
            CartExistance.Voucher = updateshoppingCart.Voucher;
            _context.ShoppingCart.Update(CartExistance);
            await _context.SaveChangesAsync();
        }
        #endregion Methods

    }
}