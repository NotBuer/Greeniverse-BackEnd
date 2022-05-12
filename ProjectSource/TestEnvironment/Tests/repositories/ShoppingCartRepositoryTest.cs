using Greeniverse.src.data;
using Greeniverse.src.dtos;
using Greeniverse.src.repositories.implementations;
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
        private void CreateThreeShoppingCartsReturnsThreeShoppingCartNotNull()
        {

        }

        [TestMethod]
        private void GetCartByDeliveryAddressReturnsNotNull()
        {

        }

        [TestMethod]
        private void GetCartByIdReturnNotNullAndPaymentMethod()
        {

        }

    }
}
