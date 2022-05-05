using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greeniverse.src.data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Greeniverse.src.models;
using Greeniverse.src.utils;

namespace TestEnvironment.Tests.data
{
    
    [TestClass]
    public class GreeniverseContextTest
    {

        private GreeniverseContext _context;

        /// <summary>
        /// Initialize the Memory database for the test porpuses environment.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            DbContextOptions<GreeniverseContext> options = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse")
                .Options;

            _context = new GreeniverseContext(options);
        }


        #region USER_TEST
        /// <summary>
        /// Inserts a new user inside the User table.
        /// </summary>
        [TestMethod]
        public void TestUserInsertInDBReturnUser()
        {
            UserModel userTest = new UserModel("TestUser", "testemail@email.com", "testpassword", "TestAdress", 123456789, UserType.IndividualPerson);
            _context.User.Add(userTest);
            _context.SaveChanges();
            Assert.IsNotNull(userTest);
        }

        /// <summary>
        /// Update a new user inside the User table.
        /// </summary>
        [TestMethod]
        public void TestUserUpdateInDBReturnUser()
        {
            // TODO: Implement update test later on.
        }

        /// <summary>
        /// Delete a new user inside the User table.
        /// </summary>
        [TestMethod]
        public void TestUserDeleteInDBReturnUser()
        {
            // TODO: Implement delete test later on.
        }
        #endregion


        #region STOCK_TEST
        /// <summary>
        /// Inserts a new stock product inside the stock table.
        /// </summary>
        [TestMethod]
        public void TestStockInsertInDBReturnStock()
        {
            StockModel stock = new StockModel("ProductTypeTest", "ProductDescription", 99.00f, "ProductName", "Samsung");
            _context.Stock.Add(stock);
            _context.SaveChanges();
            Assert.IsNotNull(stock);
        }

        /// <summary>
        /// Update a new stock product inside the stock table.
        /// </summary>
        [TestMethod]
        public void TestStockUpdateInDBReturnStock()
        {
            // TODO: Implement update test later on.
        }

        /// <summary>
        /// Delete a new stock product inside the stock table.
        /// </summary>
        [TestMethod]
        public void TestStockDeleteInDBReturnStock()
        {
            // TODO: Implement delete test later on.
        }
        #endregion


        #region SHOPPINGCART_TEST
        /// <summary>
        /// Inserts a new shopping cart inside the cart table.
        /// </summary>
        [TestMethod]
        public void TestShoppingCartInsertInDBReturnCart()
        {
            ShoppingCartModel cart = new ShoppingCartModel(10, PaymentMethod.CreditCard, "100OFF", "TestAddress", 100, 9500);
            _context.ShoppingCart.Add(cart);
            _context.SaveChanges();
            Assert.IsNotNull(cart);
        }

        /// <summary>
        /// Update a new shopping cart inside the cart table.
        /// </summary>
        [TestMethod]
        public void TestShoppingCartUpdateInDBReturnCart()
        {
            // TODO: Implement update test later on.
        }

        /// <summary>
        /// Delete a new shopping cart inside the cart table.
        /// </summary>
        [TestMethod]
        public void TestShoppingCartDeleteInDBReturnCart()
        {
            // TODO: Implement delete test later on.
        }
        #endregion

    }
}
