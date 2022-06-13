using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Greeniverse.src.utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    /// <summary>
    /// <para>Resume: Interface responsible for representing CRUD actions stock</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 05/13/2022</para>
       /// </summary>
    public interface IStock
    {
        Task NewProductAsync(NewStockDTO Product);
        Task UpdateProductAsync(UpdateStockDTO Updateproduct);
        Task DeleteProductAsync(int id);
        Task <StockModel> GetProductByIdAsync(int id);
        Task<List<StockModel>> GetAllProductsStockAsync(QueryFilter queryFilter);
        Task<List<StockModel>> GetProductsBySearchAsync(ProductCategory productCategory, string description, string productName, QueryFilter queryFilter);
        Task<List<StockModel>> GetProductByCategoryAsync(ProductCategory productCategory, QueryFilter queryFilter);
    }
}