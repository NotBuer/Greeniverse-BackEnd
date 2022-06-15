using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.models;
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
                      PaymentMethod.PIX, "50% de Desconto", "AddressTest", "murilinho@gmail.com", 1)
              );

            Assert.IsNotNull(_context.ShoppingCart.FirstOrDefault(s => s.Id == 1));
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
                        PaymentMethod.PIX, "10% de Desconto", "AddressTest", "catel@gmail.com", 2)
            );

            await _repositorySC.NewShoppingCartAsync(
                    new NewShoppingCartDTO(
                        PaymentMethod.Paypal, "5% de Desconto", "AddressTest", "rodrigofeliz@gmail.com", 3)
            );

            List<ShoppingCartModel> firstList = await _repositorySC.GetAllProductsByEmailPurchaserAsync("catel@gmail.com");
            List<ShoppingCartModel> secondList = await _repositorySC.GetAllProductsByEmailPurchaserAsync("rodrigofeliz@gmail.com");

            Assert.IsNotNull(firstList);
            Assert.IsNotNull(secondList);
        }

        [TestMethod]
        private async Task GetCartByIdReturnPaymentMethod()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse1")
                .Options;

            _context = new GreeniverseContext(opt);
            _repositorySC = new ShoppingCartRepository(_context);

            await _repositorySC.NewShoppingCartAsync(
                new NewShoppingCartDTO(
                    PaymentMethod.CreditCard, "25% de Desconto", "AddressTest", "kauzinha@gmail.com", 5)
            );

            ShoppingCartModel model = await _repositorySC.GetShoppingCartByIdAsync(1);

            Assert.AreEqual(model.PaymentMethod, PaymentMethod.CreditCard);
        }

    }
}
