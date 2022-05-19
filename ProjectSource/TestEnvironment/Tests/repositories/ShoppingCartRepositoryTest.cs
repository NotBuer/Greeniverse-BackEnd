using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
using Greeniverse.src.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEnvironment.Tests.repositories
{

    [TestClass]
    public class ShoppingCartRepositoryTest
    {
        private GreeniverseContext _context;
        private IUser _repositoryU;
        private IStock _repositoryS;
        private IShoppingCart _repositorySC;

        [TestMethod]
        private async Task CreateShoppingCartsReturnsShoppingCartNotNull()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse1")
                .Options;

            _context = new GreeniverseContext(opt);
            _repositorySC = new ShoppingCartRepository(_context);

            await _repositorySC.NewShoppingCartAsync(
                  new NewShoppingCartDTO(
                      10, PaymentMethod.PIX, "50% de Desconto", "AddressTest", "murilinho@gmail.com", 1)
              );

            Assert.AreEqual(1, _context.ShoppingCart.Count());
        }

        [TestMethod]
        private async Task GetAllProductsByEmailPurchaserAsyncReturnsNotNull()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse1")
                .Options;

            _context = new GreeniverseContext(opt);
            _repositorySC = new ShoppingCartRepository(_context);

            await _repositorySC.NewShoppingCartAsync(
                 new NewShoppingCartDTO(
                     5, PaymentMethod.PIX, "10% de Desconto", "AddressTest", "catel@gmail.com", 2)
             );

        }

        [TestMethod]
        private async Task GetCartByIdReturnNotNullAndPaymentMethod()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse1")
                .Options;

            _context = new GreeniverseContext(opt);
            _repositorySC = new ShoppingCartRepository(_context);

            await _repositorySC.NewShoppingCartAsync(
                new NewShoppingCartDTO(
                    12, PaymentMethod.CreditCard, "25% de Desconto", "AddressTest", "kauzinha@gmail.com", 5)
            );

        }

    }
}
