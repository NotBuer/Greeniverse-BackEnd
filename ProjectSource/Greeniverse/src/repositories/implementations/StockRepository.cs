using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> 4ee11c44acf4c64cf92bc6e5860d2698e9c84519
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
<<<<<<< HEAD
        #endregion builders

        #region Methods
        public void UpdateProduct(UpdateStockDTO Updateproduct)
        {
            StockModel ProductExistent = GetProductById(Updateproduct.Id);
            ProductExistent.Description = ProductExistent.Description;
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

    }
       #endregion
=======

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
>>>>>>> 4ee11c44acf4c64cf92bc6e5860d2698e9c84519
}
