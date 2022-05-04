using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IShoppingCart
    {
        void NewShoppingCart(NewShoppingCartDTO ShoppingCart);
<<<<<<< HEAD

        void UpdateShoppingCart(UpdateShoppingCartDTO updateshoppingCart);

        void DeleteShoppingCart(int id);

        ShoppingCartModel GetShoppingCartById(int id);
        ShoppingCartModel GetShoppingCartByPurchaseStatus(string purchaseStatus);

        List<ShoppingCartModel> GetAllProducts();
       

=======
        void UpdateShoppingCart(UpdateShoppingCartDTO UpdateShoppingCart);
        void DeleteShoppingCart(int id);
>>>>>>> d2bbdc45a6f1179373fa6b582320c62129c0111d

        ShoppingCartModel GetShoppingCartById(int id);
        ShoppingCartModel GetShoppingCartByPurchaseStatus(string purchaseStatus);
        List<ShoppingCartModel> GetAllProducts();
        
    }
}
