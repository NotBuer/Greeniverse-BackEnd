using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions ShoppingCart.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 13/05/2022</para>
    /// </summary>
    
    public interface IShoppingCart
    {
        Task NewShoppingCartAsync(NewShoppingCartDTO ShoppingCart);
        Task UpdateShoppingCartAsync(UpdateShoppingCartDTO UpdateShoppingCart);
        Task DeleteShoppingCartAsync(int id);

        Task<ShoppingCartModel> GetShoppingCartByIdAsync(int id);
        Task<List<ShoppingCartModel>> GetAllProductsAsync();
        
    }
}
