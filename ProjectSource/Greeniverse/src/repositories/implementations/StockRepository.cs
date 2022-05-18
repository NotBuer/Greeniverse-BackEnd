using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greeniverse.src.repositories.implementations
{
    /// <summary>
    /// <para>Resume: Class responsible for implement methods CRUD Stock.</para>
    /// <para>Version: 1.0</para>
    /// <para>Date:05/13/2022</para>
    /// </summary>
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

        /// <summary>
        /// <para>Resume: method for add new product.</para>
        /// </summary>
        /// <param name="Product">NewStockDTO</param>
        /// <returns>StockModel</returns>
        public async Task NewProductAsync(NewStockDTO Product)
        {
           await _context.Stock.AddAsync(new StockModel
            {
                ProductName = Product.ProductName,
                Type = Product.Type,
                Description = Product.Description,
                Price = Product.Price,
                Provider = Product.Provider,
                ProductPhoto = Product.ProductPhoto

            });
           await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for update existent product.</para>
        /// </summary>
        /// <param name="Updateproduct">StockUpdateDTO</param>
        /// <returns>StockModel</returns>
        public async Task UpdateProductAsync(UpdateStockDTO Updateproduct)
        {
            StockModel ProductExistent =await GetProductByIdAsync(Updateproduct.Id);
            ProductExistent.Type = Updateproduct.Type;
            ProductExistent.Description = Updateproduct.Description;
            ProductExistent.Price = Updateproduct.Price;
            ProductExistent.Provider = Updateproduct.Provider;
            ProductExistent.ProductPhoto = Updateproduct.ProductPhoto;
        }

        /// <summary>
        /// <para>Resume: method for delete existent product.</para>
        /// </summary>
        /// <param name="id">Id of stock</param>
        public async Task DeleteProductAsync(int id)
        {
            _context.Stock.Remove(await GetProductByIdAsync(id));
           await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for get post by id.</para>
        /// </summary>
        /// <param name="id">Id of product</param>
        /// <returns>StockModel</returns>
        public async Task<StockModel> GetProductByIdAsync(int id)
        {
            return await _context.Stock.FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// <para>Resume: Query method for get stock by type or description and productname creator</para>
        /// </summary>
        /// <param name="type">Type of product</param>
        /// <param name="description">Description of product</param>
        /// <param name="productName">ProductName of product</param>
        /// <returns>List of StockModel</returns>
        public async Task<List<ShoppingCartModel>> GetProductsBySearchAsync(string type, string description, string productName)
        {

            switch (type, description, productName)
            {
                case (null, null, null): return await _context.ShoppingCart.ToListAsync();
                case (null, null, _):
                    return await _context.ShoppingCart
                       .Include(s => s.Purchaser)
                       .Include(s => s.Product)
                       .Where(s => s.Product.ProductName.Contains(productName))
                       .ToListAsync();

                case (null, _, null):
                    return await _context.ShoppingCart
                       .Include(s => s.Purchaser)
                       .Include(s => s.Product)
                       .Where(s => s.Product.Description.Contains(description))
                       .ToListAsync();

                case (_, null, null):
                    return await _context.ShoppingCart
                      .Include(s => s.Purchaser)
                      .Include(s => s.Product)
                      .Where(s => s.Product.Type.Contains(type))
                      .ToListAsync();

                case (_, _, null):
                    return await _context.ShoppingCart
                        .Include(s => s.Purchaser)
                        .Include(s => s.Product)
                        .Where(s => s.Product.Type.Contains(type) & s.Product.Description.Contains(description))
                        .ToListAsync(); 

                case (null, _, _):
                    return await _context.ShoppingCart
                      .Include(s => s.Purchaser)
                      .Include(s => s.Product)
                      .Where(s => s.Product.Description.Contains(description) & s.Product.ProductName.Contains(productName))
                      .ToListAsync();  

                case (_, null, _):
                    return await _context.ShoppingCart
                       .Include(s => s.Purchaser)
                       .Include(s => s.Product)
                       .Where(s => s.Product.Type.Contains(type) & s.Product.ProductName.Contains(productName))
                       .ToListAsync();

                case (_, _, _):
                    return await _context.ShoppingCart
                       .Include(s => s.Purchaser)
                       .Include(s => s.Product)
                       .Where(s => s.Product.Type.Contains(type) |
                       s.Product.Description.Contains(description) | 
                       s.Product.ProductName.Contains(productName))
                       .ToListAsync();
            }
        }

        /// <summary>
        /// <para>Resume: method for get all products.</para>
        /// </summary>
        /// <returns>List of StockModel</returns>
        public async Task<List<StockModel>> GetAllProductsStockAsync()
        {
            return await _context.Stock
                .ToListAsync();
        }
        #endregion

    }
}
