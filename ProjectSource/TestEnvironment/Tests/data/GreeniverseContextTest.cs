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
            UserModel userTest = new UserModel("TestUser", "testemail@email.com", "testpassword", "TestAdress", "123456789", UserType.IndividualPerson, 1000);
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
            // First add a new user to make updating it possible.
            UserModel userTest = new UserModel("TestUser", "testemail@email.com", "testpassword", "TestAdress", "123456789", UserType.IndividualPerson, 1000);
            _context.User.Add(userTest);
            _context.SaveChanges();

            // Now make the changes on the user data.
            UserModel userToUpdate = _context.User.FirstOrDefault(u => u.Name == "TestUser");
            userToUpdate.Name = "UserTestName";
            _context.Update(userToUpdate);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete a new user inside the User table.
        /// </summary>
        [TestMethod]
        public void TestUserDeleteInDBReturnUser()
        {
            // First add a new user to make deleting it possible.
            UserModel userTest = new UserModel("TestUser", "testemail@email.com", "testpassword", "TestAdress", "123456789", UserType.IndividualPerson, 1000);
            _context.User.Add(userTest);
            _context.SaveChanges();

            // Now that we have at least one user available to be deleted, then delete it.
            _context.User.Remove(userTest);
            _context.SaveChanges();
        }
        #endregion


        #region STOCK_TEST
        /// <summary>
        /// Inserts a new stock product inside the stock table.
        /// </summary>
        [TestMethod]
        public void TestStockInsertInDBReturnStock()
        {
            StockModel stock = new StockModel(ProductCategory.GroceryStore, "ProductDescription", 99.00f, "ProductName", 2, "Samsung");
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
            // First add a new stock product to make updating it possible.
            StockModel stock = new StockModel(ProductCategory.DrinksAndDairy, "ProductDescription", 99.00f, "ProductName", 2, "Samsung");
            _context.Stock.Add(stock);
            _context.SaveChanges();

            // Now make the changes on the stock product data.
            StockModel stockToUpdate = _context.Stock.FirstOrDefault(s => s.ProductName == "ProductTypeTest");
            _context.Update(stock);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete a new stock product inside the stock table.
        /// </summary>
        [TestMethod]
        public void TestStockDeleteInDBReturnStock()
        {
            // First add a new user to make deleting it possible.
            StockModel stock = new StockModel(ProductCategory.Vegetables, "ProductDescription", 99.00f, "ProductName", 2, "Samsung");
            _context.Stock.Add(stock);
            _context.SaveChanges();

            // Now that we have at least one stock available to be deleted, then delete it
            _context.Stock.Remove(stock);
            _context.SaveChanges();
        }
        #endregion


        #region SHOPPINGCART_TEST
        /// <summary>
        /// Inserts a new shopping cart inside the cart table.
        /// </summary>
        [TestMethod]
        public void TestShoppingCartInsertInDBReturnCart()
        {
            ShoppingCartModel cart = new ShoppingCartModel(PaymentMethod.CreditCard, "100OFF", "TestAddress");
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
            // First add a new cart to make updating it possible.
            ShoppingCartModel cart = new ShoppingCartModel(PaymentMethod.CreditCard, "100OFF", "TestAddress");
            _context.ShoppingCart.Add(cart);
            _context.SaveChanges();

            // Now make the changes on the shopping cart data.
            ShoppingCartModel cartToUpdate = _context.ShoppingCart.FirstOrDefault(c => c.DeliveryAddress == "TestAddress");
            _context.ShoppingCart.Update(cartToUpdate);
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete a new shopping cart inside the cart table.
        /// </summary>
        [TestMethod]
        public void TestShoppingCartDeleteInDBReturnCart()
        {
            // First add a new shopping cart to make deleting it possible.
            ShoppingCartModel cart = new ShoppingCartModel(PaymentMethod.CreditCard, "100OFF", "TestAddress");
            _context.ShoppingCart.Add(cart);
            _context.SaveChanges();

            // Now that we have at least one shopping cart available to be deleted, then delete it
            _context.ShoppingCart.Remove(cart);
            _context.SaveChanges();
        }
        #endregion

    }
}
