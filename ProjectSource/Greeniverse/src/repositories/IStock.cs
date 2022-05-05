using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IStock
    {
        void NewProduct(NewStockDTO Product);
        void UpdateProduct(UpdateStockDTO Updateproduct);
        void DeleteProduct(int id);
        StockModel GetProductById(int id);
        List<StockModel> GetAllProducts();
        List<StockModel> GetProductsBySearch(string type, string description, string productName , string creatorname);
    }
}

    

