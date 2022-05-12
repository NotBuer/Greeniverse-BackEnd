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
        public async Task GetStockByDescriptionReturnProductName()
        {
            GreeniverseContext _context;
            StockRepository _repository;

            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
            .UseInMemoryDatabase(databaseName: "db_greeniverse")
            .Options;

            _context = new GreeniverseContext(opt);
            _repository = new StockRepository(_context);


            await _repository.NewStockAsync(new NewStockDTO("Banana"));

            await _repository.NewStockAsync(new NewStockDTO("Morango"));

            var stock = await _repositoriy.GetStockByDescriptionAsync("Banana");


            Assert.AreEqual(2, stock.Count);
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
            _context = new GreeniverseContext(opt);
            _repository = new StockRepository(_context);


            await _repository.NovoTemaAsync(new NewStockDTO("Banana"));

            await _repository.UpdateStockAsync(new UpdateStockDTO(1, "Morango"));

            var stock = await _repository.GetStockByIdAsync(1);

            Assert.AreEqual("Morango", stock.Description);
        }
    }
}

   
