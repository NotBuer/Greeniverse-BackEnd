using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IStock
    {
        
        void NewProduct(NewProductDTO Product);
        void UpdateProduct(UpdateProductDTO UpdateProduct);
        void DeleteProduct(int id);
        StockModel GetProductById(int id);
        List<StockModel> GetAllProducts();
        List<StockModel> GetProductBySearch(string type, string description, string productName, string creatorName);
    }
}

    

