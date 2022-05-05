<<<<<<< HEAD
﻿using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Linq;

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
        public void DeleteShoppingCart(int id)
        {
            _context.ShoppingCart.Remove(GetShoppingCartById(id));
            _context.SaveChanges();
        }
=======
﻿
        public List<ShoppingCartModel> GetAllProducts()
        {
            return _context.ShoppingCart.ToList();
        }

        public ShoppingCartModel GetShoppingCartById(int id)
        {
            return _context.ShoppingCart.FirstOrDefault(s => s.Id == id);
        }

        public void NewShoppingCart(NewShoppingCartDTO ShoppingCart)
        {
            _context.ShoppingCart.Add(new ShoppingCartModel
            {
                AmountProduct = ShoppingCart.AmountProduct,
                PaymentMethod = ShoppingCart.PaymentMethod,
                Voucher = ShoppingCart.Voucher,
                DeliveryAdress = ShoppingCart.DeliveryAdress,
            });
            _context.SaveChanges();
        }
        public void UpdateShoppingCart(UpdateShoppingCartDTO updateshoppingCart)
        {
        var CartExistance = GetShoppingCartById(updateshoppingCart.Id);
        CartExistance.AmountProduct = updateshoppingCart.AmountProduct;
        CartExistance.PaymentMethod = updateshoppingCart.PaymentMethod;
        CartExistance.Voucher = updateshoppingCart.Voucher;
        _context.ShoppingCart.Update(CartExistance);
        _context.SaveChanges();
        }
        #endregion Methods

    }
}
>>>>>>> 89317c4c90b01060349179974122bbffe4fd0eb4
