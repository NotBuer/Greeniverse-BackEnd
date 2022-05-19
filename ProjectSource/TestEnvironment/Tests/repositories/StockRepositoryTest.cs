using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
using Greeniverse.src.repositories;
using Greeniverse.src.repositories.implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEnvironment.Tests.repositories
{
    [TestClass]
    public class StockRepositoryTest
    {
        /// <summary>
        /// Get products by search with parameters
        /// </summary>
        [TestMethod]
        public async Task GetStockBySearchReturnProductDescriptionComparisonAsync()
        {
            GreeniverseContext _context;
            StockRepository _repository;

            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
            .UseInMemoryDatabase(databaseName: "db_greeniverse1")
            .Options;

            _context = new GreeniverseContext(opt);
            _repository = new StockRepository(_context);

            await _repository.NewProductAsync(new NewStockDTO
                (1, "Fruit", "Banana description", 9.99f, "Banana", "ABCDE", "ProductURL"));

            List<ShoppingCartModel>stock = await _repository.GetProductsBySearchAsync("Fruit", "Banana description", "Banana");

            Assert.AreEqual("Banana description", stock.Where(s => s.Product.Type == "Fruit").FirstOrDefault().Product.Description);
        }

        /// <summary>
        /// Inserting products in the bank and getting product by Id
        /// </summary>
        [TestMethod]
        public async Task AlternateStockDescriptionReturnTypeAsync()
        {
            GreeniverseContext _context;
            StockRepository _repository;

            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
            .UseInMemoryDatabase(databaseName: "db_greeniverse")
            .Options;

            _context = new GreeniverseContext(opt);
            _repository = new StockRepository(_context);


            await _repository.NewProductAsync(new NewStockDTO
                (1, "Fruit", "Banana description", 9.99f, "Banana", "ABCDE", "ProductURL"));

            await _repository.NewProductAsync(new NewStockDTO
                (2, "Fruit", "Morango description", 5.99f, "Morango", "FGHIJ", "ProductURL"));

            var stock = await _repository.GetProductByIdAsync(1);

            Assert.AreEqual("Banana description", stock.Description);
        }
    }
}

   
