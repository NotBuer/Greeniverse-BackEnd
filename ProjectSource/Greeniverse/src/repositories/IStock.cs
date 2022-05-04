using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public interface IStock
    {
<<<<<<< HEAD
        void NewProduct(NewProductDTO Product);
        void UpdateProduct(UpdateProductDTO Updateproduct);

        void DeleteProduct(int id);
        StockModel GetProductById(int id);
        List<StockModel> GetAllProducts();
        List<StockModel> CatchProductsBySearch(string type, string description, string productName , string creatorname);
=======
        
        void NewProduct(NewProductDTO Product);
        void UpdateProduct(UpdateProductDTO UpdateProduct);
        void DeleteProduct(int id);
        StockModel GetProductById(int id);
        List<StockModel> GetAllProducts();
        List<StockModel> GetProductBySearch(string type, string description, string productName, string creatorName);
>>>>>>> d2bbdc45a6f1179373fa6b582320c62129c0111d
    }
}

    

