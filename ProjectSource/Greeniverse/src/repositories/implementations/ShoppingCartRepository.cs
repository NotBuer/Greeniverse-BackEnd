using Greeniverse.src.data;
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
