using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IShoppingCart
    {
        void NewShoppingCart(NewShoppingCartDTO ShoppingCart);
        void UpdateShoppingCart(UpdateShoppingCartDTO UpdateShoppingCart);
        void DeleteShoppingCart(int id);

        ShoppingCartModel GetShoppingCartById(int id);
        ShoppingCartModel GetShoppingCartByPurchaseStatus(string purchaseStatus);
        List<ShoppingCartModel> GetAllProducts();
        
    }
}
