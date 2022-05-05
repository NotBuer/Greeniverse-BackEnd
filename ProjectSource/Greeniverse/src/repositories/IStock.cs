<<<<<<< HEAD
﻿using Greeniverse.src.dtos;
using Greeniverse.src.models;
=======
﻿using Greeniverse.src.models;
using Greeniverse.src.dtos;
>>>>>>> ab382365a4a9355469d58a908bdfc4c4820d7415
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

    

