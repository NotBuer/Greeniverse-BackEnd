using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    public interface IShoppingCart
    {
        Task NewShoppingCartAsync(NewShoppingCartDTO ShoppingCart);
        Task UpdateShoppingCartAsync(UpdateShoppingCartDTO UpdateShoppingCart);
        Task DeleteShoppingCartAsync(int id);

        Task<ShoppingCartModel> GetShoppingCartByIdAsync(int id);
        Task<List<ShoppingCartModel>> GetAllProductsAsync();
        
    }
}
