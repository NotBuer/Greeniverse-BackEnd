using Greeniverse.src.data;
using Greeniverse.src.DTOS;
using Greeniverse.src.repositories.implementations;
using Greeniverse.src.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace GreeniverseTest.Tests.repositories
{

    [TestClass]
    public class UserRepositoryTest
    {
        private GreeniverseContext _context;
        private IUser _repository;

        [TestMethod]
        public async Task CreateTwoUsersInDBReturnTwoUsersAsync()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse1")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            await _repository.NewUserAsync(
                  new NewUserDTO(
                      "Thamy Cavalcanti", "thamy@email.com", "12345678", "AddressTest", "123456789", UserType.IndividualPerson, 1000)
              );

            await _repository.NewUserAsync(
                 new NewUserDTO(
                     "Gaby Peres", "gaby@email.com", "87654321", "AdressTest", "987654321", UserType.Business, 1000)
             );

            Assert.AreEqual(2, _context.User.Count());
        }

        [TestMethod]
        public async Task GetUserByEmailReturnNotNullAsync()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse2")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            await _repository.NewUserAsync(
                  new NewUserDTO(
                      "RodrigoFranca", "rodrigo@email.com", "12345678", "TestAddress", "368536321", UserType.IndividualPerson, 1000)
              );

            var user = await _repository.GetUserByEmailAsync("rodrigo@email.com");

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public async Task GetUserByIdReturnNotNullAndUserNameAsync()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse3")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            await _repository.NewUserAsync(
                 new NewUserDTO(
                     "Murilo Gama", "murilo@email.com", "38194093", "TestAddress", "582950126", UserType.Business, 1000)
             );

            var user = await _repository.GetUserByIdAsync(1);

            Assert.IsNotNull(user);

            Assert.AreEqual("Murilo Gama", user.Name);
        }

        [TestMethod]
        public async Task UpdateUserReturnUserUpdatedAsync()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse4")
                .Options;

            _context = new GreeniverseContext(opt);
           _repository = new UserRepository(_context);

            await _repository.NewUserAsync(
                  new NewUserDTO(
                      "Uriel Pereira", "uriel@email.com", "48291038", "AddressTest", "520584015", UserType.IndividualPerson, 1000)
              );

            var old = await _repository.GetUserByEmailAsync("uriel@email.com");
            await _repository.UpdateUserAsync(
                 new UpdateUserDTO(
                         "Uriel Pereira", "urielpereira@email.com", "12345678", "AddressTest", "520584015", UserType.IndividualPerson, 1000)
             );

            Assert.AreEqual(
                "Uriel Pereira",
                _context.User.FirstOrDefault(u => u.Id == old.Id).Name);

            Assert.AreEqual(
                "12345678",
                _context.User.FirstOrDefault(u => u.Id == old.Id).Password);
        }
    }
}