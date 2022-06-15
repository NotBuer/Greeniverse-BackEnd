using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Greeniverse.src.utils;
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
                ProductCategory = Product.ProductCategory,
                Description = Product.Description,
                Price = Product.Price,
                ProductAmount = Product.ProductAmount,
                Provider = Product.Provider,
                ProductPhoto = Product.ProductPhoto

            });
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resume: method for update existent product.</para>
        /// </summary>
        /// <param name="UpdateProduct">StockUpdateDTO</param>
        /// <returns>StockModel</returns>
        public async Task UpdateProductAsync(UpdateStockDTO UpdateProduct)
        {
            StockModel ProductExistent = await GetProductByIdAsync(UpdateProduct.Id);
            ProductExistent.ProductCategory = UpdateProduct.ProductCategory;
            ProductExistent.Description = UpdateProduct.Description;
            ProductExistent.Price = UpdateProduct.Price;
            ProductExistent.ProductAmount = UpdateProduct.ProductAmount;
            ProductExistent.Provider = UpdateProduct.Provider;
            ProductExistent.ProductPhoto = UpdateProduct.ProductPhoto;
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
        /// <para>Resume: Query method for get stock by type or description or product name</para>
        /// </summary>
        /// <param name="productCategory">Type of product</param>
        /// <param name="description">Description of product</param>
        /// <param name="productName">ProductName of product</param>
        /// <returns>List of StockModel</returns>
        public async Task<List<StockModel>> GetProductsBySearchAsync(ProductCategory productCategory, string description, string productName, QueryFilter queryFilter)
        {

            #region QUERYFILTER_DEFAULT
            if (queryFilter == QueryFilter.Default)
            {
                switch (productCategory, description, productName)
                {
                    case (ProductCategory.NULL, null, null): return await _context.Stock.ToListAsync();

                    case (ProductCategory.NULL, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductName.Contains(productName))
                           .ToListAsync();

                    case (ProductCategory.NULL, _, null):
                        return await _context.Stock
                           .Where(s => s.Description.Contains(description))
                           .ToListAsync();

                    case (_, null, null):
                        return await _context.Stock
                          .Where(s => s.ProductCategory.Equals(productCategory))
                          .ToListAsync();

                    case (_, _, null):
                        return await _context.Stock
                            .Where(s => s.ProductCategory.Equals(productCategory) & s.Description.Contains(description))
                            .ToListAsync();

                    case (ProductCategory.NULL, _, _):
                        return await _context.Stock
                          .Where(s => s.Description.Contains(description) & s.ProductName.Contains(productName))
                          .ToListAsync();

                    case (_, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) & s.ProductName.Contains(productName))
                           .ToListAsync();

                    case (_, _, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) |
                           s.Description.Contains(description) |
                           s.ProductName.Contains(productName))
                           .ToListAsync();
                }
            }
            #endregion


            #region QUERYFILTER_MINORPRICE
            if (queryFilter == QueryFilter.MinorPrice)
            {
                switch (productCategory, description, productName)
                {
                    case (ProductCategory.NULL, null, null): return await _context.Stock.ToListAsync();

                    case (ProductCategory.NULL, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductName.Contains(productName))
                           .OrderBy(s => s.Price)
                           .ToListAsync();

                    case (ProductCategory.NULL, _, null):
                        return await _context.Stock
                           .Where(s => s.Description.Contains(description))
                           .OrderBy(s => s.Price)
                           .ToListAsync();

                    case (_, null, null):
                        return await _context.Stock
                          .Where(s => s.ProductCategory.Equals(productCategory))
                          .OrderBy(s => s.Price)
                          .ToListAsync();

                    case (_, _, null):
                        return await _context.Stock
                            .Where(s => s.ProductCategory.Equals(productCategory) & s.Description.Contains(description))
                            .OrderBy(s => s.Price)
                            .ToListAsync();

                    case (ProductCategory.NULL, _, _):
                        return await _context.Stock
                          .Where(s => s.Description.Contains(description) & s.ProductName.Contains(productName))
                          .OrderBy(s => s.Price)
                          .ToListAsync();

                    case (_, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) & s.ProductName.Contains(productName))
                           .OrderBy(s => s.Price)
                           .ToListAsync();

                    case (_, _, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) |
                           s.Description.Contains(description) |
                           s.ProductName.Contains(productName))
                           .OrderBy(s => s.Price)
                           .ToListAsync();
                }
            }
            #endregion


            #region QUERYFILTER_MAJORPRICE
            if (queryFilter == QueryFilter.MajorPrice)
            {
                switch (productCategory, description, productName)
                {
                    case (ProductCategory.NULL, null, null): return await _context.Stock.ToListAsync();

                    case (ProductCategory.NULL, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductName.Contains(productName))
                           .OrderByDescending(s => s.Price)
                           .ToListAsync();

                    case (ProductCategory.NULL, _, null):
                        return await _context.Stock
                           .Where(s => s.Description.Contains(description))
                           .OrderByDescending(s => s.Price)
                           .ToListAsync();

                    case (_, null, null):
                        return await _context.Stock
                          .Where(s => s.ProductCategory.Equals(productCategory))
                          .OrderByDescending(s => s.Price)
                          .ToListAsync();

                    case (_, _, null):
                        return await _context.Stock
                            .Where(s => s.ProductCategory.Equals(productCategory) & s.Description.Contains(description))
                            .OrderByDescending(s => s.Price)
                            .ToListAsync();

                    case (ProductCategory.NULL, _, _):
                        return await _context.Stock
                          .Where(s => s.Description.Contains(description) & s.ProductName.Contains(productName))
                          .OrderByDescending(s => s.Price)
                          .ToListAsync();

                    case (_, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) & s.ProductName.Contains(productName))
                           .OrderByDescending(s => s.Price)
                           .ToListAsync();

                    case (_, _, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) |
                           s.Description.Contains(description) |
                           s.ProductName.Contains(productName))
                           .OrderByDescending(s => s.Price)
                           .ToListAsync();
                }
            }
            #endregion


            #region QUERYFILTER_ALPHABETICAL
            if (queryFilter == QueryFilter.Alphabetical)
            {
                switch (productCategory, description, productName)
                {
                    case (ProductCategory.NULL, null, null): return await _context.Stock.ToListAsync();

                    case (ProductCategory.NULL, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductName.Contains(productName))
                           .OrderBy(s => s.ProductName)
                           .ToListAsync();

                    case (ProductCategory.NULL, _, null):
                        return await _context.Stock
                           .Where(s => s.Description.Contains(description))
                           .ToListAsync();

                    case (_, null, null):
                        return await _context.Stock
                          .Where(s => s.ProductCategory.Equals(productCategory))
                          .ToListAsync();

                    case (_, _, null):
                        return await _context.Stock
                            .Where(s => s.ProductCategory.Equals(productCategory) & s.Description.Contains(description))
                            .ToListAsync();

                    case (ProductCategory.NULL, _, _):
                        return await _context.Stock
                          .Where(s => s.Description.Contains(description) & s.ProductName.Contains(productName))
                          .OrderBy(s => s.ProductName)
                          .ToListAsync();

                    case (_, null, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) & s.ProductName.Contains(productName))
                           .OrderBy(s => s.ProductName)
                           .ToListAsync();

                    case (_, _, _):
                        return await _context.Stock
                           .Where(s => s.ProductCategory.Equals(productCategory) |
                           s.Description.Contains(description) |
                           s.ProductName.Contains(productName))
                           .OrderBy(s => s.ProductName)
                           .ToListAsync();
                }
            }
            #endregion


            #region DEFAULT_RETURN
            switch (productCategory, description, productName)
            {
                case (ProductCategory.NULL, null, null): return await _context.Stock.ToListAsync();

                case (ProductCategory.NULL, null, _):
                    return await _context.Stock
                       .Where(s => s.ProductName.Contains(productName))
                       .ToListAsync();

                case (ProductCategory.NULL, _, null):
                    return await _context.Stock
                       .Where(s => s.Description.Contains(description))
                       .ToListAsync();

                case (_, null, null):
                    return await _context.Stock
                      .Where(s => s.ProductCategory.Equals(productCategory))
                      .ToListAsync();

                case (_, _, null):
                    return await _context.Stock
                        .Where(s => s.ProductCategory.Equals(productCategory) & s.Description.Contains(description))
                        .ToListAsync();

                case (ProductCategory.NULL, _, _):
                    return await _context.Stock
                      .Where(s => s.Description.Contains(description) & s.ProductName.Contains(productName))
                      .ToListAsync();

                case (_, null, _):
                    return await _context.Stock
                       .Where(s => s.ProductCategory.Equals(productCategory) & s.ProductName.Contains(productName))
                       .ToListAsync();

                case (_, _, _):
                    return await _context.Stock
                       .Where(s => s.ProductCategory.Equals(productCategory) |
                       s.Description.Contains(description) |
                       s.ProductName.Contains(productName))
                       .ToListAsync();
            }
            #endregion]

        }

        /// <summary>
        /// <para>Resume: method for get all products.</para>
        /// </summary>
        /// <returns>List of StockModel</returns>
        public async Task<List<StockModel>> GetAllProductsStockAsync(QueryFilter queryFilter)
        {
            switch (queryFilter)
            {
                case QueryFilter.Default:
                    return await _context.Stock
                        .ToListAsync();

                case QueryFilter.MinorPrice:
                    return await _context.Stock
                        .OrderBy(s => s.Price)
                        .ToListAsync();

                case QueryFilter.MajorPrice:
                    return await _context.Stock
                        .OrderByDescending(s => s.Price)
                        .ToListAsync();

                case QueryFilter.Alphabetical:
                    return await _context.Stock
                        .OrderBy(s => s.ProductName)
                        .ToListAsync();

                default:
                    return await _context.Stock
                        .ToListAsync();
            }
        }

        /// <summary>
        /// <para>Resume: method for get all products searching for it category.</para>
        /// </summary>
        /// <returns>List of StockModel</returns>
        public async Task<List<StockModel>> GetProductByCategoryAsync(ProductCategory productCategory, QueryFilter queryFilter)
        {
            switch (queryFilter)
            {
                case QueryFilter.Default:
                    return await _context.Stock
                    .Where(s => s.ProductCategory.Equals(productCategory))
                    .ToListAsync();

                case QueryFilter.MinorPrice:
                    return await _context.Stock
                    .Where(s => s.ProductCategory.Equals(productCategory))
                    .OrderBy(s => s.Price)
                    .ToListAsync();

                case QueryFilter.MajorPrice:
                    return await _context.Stock
                    .Where(s => s.ProductCategory.Equals(productCategory))
                    .OrderByDescending(s => s.Price)
                    .ToListAsync();

                case QueryFilter.Alphabetical:
                    return await _context.Stock
                    .Where(s => s.ProductCategory.Equals(productCategory))
                    .OrderBy(s => s.ProductName)
                    .ToListAsync();

                default:
                    return await _context.Stock
                    .Where(s => s.ProductCategory.Equals(productCategory))
                    .ToListAsync();
            }
        }
        #endregion

    }
}
