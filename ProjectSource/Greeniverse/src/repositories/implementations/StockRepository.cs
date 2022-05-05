using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using System.Collections.Generic;
using System.Linq;

namespace Greeniverse.src.repositories.implementations
{
    public class StockRepository : IStock
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
            _context.Stock.Add(new StockModel
            {
                ProductName = Product.ProductName,
                Type = Product.Type,
                Description = Product.Description,
                Price = Product.Price,
                Provider = Product.Provider

            });

            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            _context.Stock.Remove(GetPostById(id));
            _context.SaveChanges();
        }

        public List<StockModel> GetAllProducts()
        {
            return _context.Stock
                .ToList();
        }

    }

    #endregion Method
}
