using System.Linq;
using System.Threading.Tasks;
using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.repositories;
using Greeniverse.src.repositories.implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEnvironment.Tests.repositories
{
    [TestClass]
    public class StockRepositoryTest
    {
        [TestMethod]
        public async Task GetStockBySearchReturnProductDescriptionComparison()
        {
            GreeniverseContext _context;
            StockRepository _repository;

            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
            .UseInMemoryDatabase(databaseName: "db_greeniverse1")
            .Options;

            _context = new GreeniverseContext(opt);
            _repository = new StockRepository(_context);

            await _repository.NewProductAsync(new NewStockDTO
                (1, "Fruit", "Banana description", 9.99f, "Banana", "ABCDE"));

            var stock = await _repository.GetProductsBySearchAsync("Fruit", "Banana Description", "Banana");

            Assert.AreEqual("Banana description", stock.FirstOrDefault(f => f.Description == "Banana description"));
        }

        [TestMethod]
        public async Task AlternateStockDescriptionReturnType()
        {
            GreeniverseContext _context;
            StockRepository _repository;

            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
            .UseInMemoryDatabase(databaseName: "db_greeniverse")
            .Options;

            _context = new GreeniverseContext(opt);
            _repository = new StockRepository(_context);


            await _repository.NewProductAsync(new NewStockDTO
                (1, "Fruit", "Banana description", 9.99f, "Banana", "ABCDE"));

            await _repository.NewProductAsync(new NewStockDTO
                (2, "Fruit", "Morango description", 5.99f, "Morango", "FGHIJ"));

            var stock = await _repository.GetProductByIdAsync(1);

            Assert.AreEqual("Morango", stock.Description);
        }
    }
}

   
