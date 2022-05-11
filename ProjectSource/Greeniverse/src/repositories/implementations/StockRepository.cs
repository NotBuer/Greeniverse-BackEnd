using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Greeniverse.src.repositories.implementations
{
    public class StockRepository : IStock
    {


        #region Attribute

        private readonly GreeniverseContext _context;

        #endregion Attribute


        #region Constructors

        public StockRepository(GreeniverseContext context)
        {
            _context = context;
        }

        #endregion 
        

        #region Methods
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
        
        public void UpdateProduct(UpdateStockDTO Updateproduct)
        {
            StockModel ProductExistent = GetProductById(Updateproduct.Id);
            ProductExistent.Description = ProductExistent.Description;
        }

        public void DeleteProduct(int id)
        {
            _context.Stock.Remove(GetProductById(id));
            _context.SaveChanges();
        }

        public StockModel GetProductById(int id)
        {
            return _context.Stock.FirstOrDefault(s => s.Id == id);
        }

        public List<StockModel> GetProductsBySearch(string type, string description, string productName)
        {

            switch (type, description, productName)
            {
                case (null, null, null): return GetAllProducts();
                case (null, null, _):
                    return _context.Stock
                   .Include(p => p.Type)
                   .Include(p => p.Description)
                   .Where(p => p.ProductName.Contains(productName))
                   .ToList();

                case (null, _, null):
                    return _context.Stock
                   .Include(p => p.Type)
                   .Include(p => p.ProductName)
                   .Where(p => p.Description.Contains(description))
                   .ToList();

                case (_, null, null):
                    return _context.Stock
                   .Include(p => p.Description)
                   .Include(p => p.ProductName)
                   .Where(p => p.Type.Contains(type))
                   .ToList();

                case (_, _, null):
                    return _context.Stock
                   .Include(p => p.ProductName)
                   .Where(p => p.Type.Contains(type) & p.Description.Contains(description))
                   .ToList();

                case (null, _, _):
                    return _context.Stock
                   .Include(p => p.Type)
                   .Where(p => p.Description.Contains(description) & p.ProductName.Contains(productName))
                   .ToList();

                case (_, null, _):
                    return _context.Stock
                   .Include(p => p.Description)
                   .Where(p => p.Type.Contains(type) & p.ProductName.Contains(productName))
                   .ToList();

                case (_, _, _):
                    return _context.Stock
                   .Where(s => s.Type.Contains(type) |
                   s.Description.Contains(description) | 
                   s.ProductName.Contains(productName))
                   .ToList();
            }
        }

        public List<StockModel> GetAllProducts()
        {
            return _context.Stock
                .ToList();
        }
        #endregion

    }
}
