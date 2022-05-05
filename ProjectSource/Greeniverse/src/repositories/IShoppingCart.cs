using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IShoppingCart
    {
        void NewShoppingCart(NewShoppingCartDTO ShoppingCart);
        void UpdateShoppingCart(UpdateShoppingCartDTO updateshoppingCart);
        void DeleteShoppingCart(int id);
        ShoppingCartModel GetShoppingCartById(int id);
        List<ShoppingCartModel> GetAllProducts();
    }
}
