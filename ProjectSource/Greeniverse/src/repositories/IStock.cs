using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IStock
    {
        void NewProduct(NewProductDTO Product);
        void UpdateProduct(UpdateProductDTO Updateproduct);
        void DeleteProduct(int id);
        StockModel GetProductById(int id);
        List<StockModel> GetAllProducts();
        List<StockModel> CatchProductsBySearch(string type, string description, string productName , string creatorname);
    }
}

    

