using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;

namespace Greeniverse.src.repositories.implementations
{
    public class StockRepository :IStock
    {
        #region Attributes

        private readonly GreeniverseContext _context;

        #endregion Attributes

        #region Builders

        public StockRepository(GreeniverseContext context)
        {
            _context = context;
        }

        #endregion Builders

        #region Method

        public void NewProduct(NewStockDTO Product)
        {
            
        }

        public void DeleteProduct(int id)
        {

        }

        public List<StockModel> GetAllProducts()
        {

        }

    }

    #endregion Method
}
