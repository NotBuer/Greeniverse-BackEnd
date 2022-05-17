using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions stock</para>
    /// <para>Version: 1.0</para>
<<<<<<< HEAD
    /// <para>Date: 03/05/2022</para>
=======
    /// <para>Date: 13/05/2022</para>
>>>>>>> 3a939ce4d050c4e140e0de017629e3aac8930c5e
    /// </summary>
    public interface IStock
    {
        Task NewProductAsync(NewStockDTO Product);
        Task UpdateProductAsync(UpdateStockDTO Updateproduct);
        Task DeleteProductAsync(int id);
        Task <StockModel> GetProductByIdAsync(int id);
        Task<List<StockModel>> GetAllProductsAsync();
        Task<List<StockModel>> GetProductsBySearchAsync(string type, string description, string productName);
    }
}

    

