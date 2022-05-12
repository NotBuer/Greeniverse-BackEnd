using Greeniverse.src.data;
using Greeniverse.src.DTOS;
using Greeniverse.src.repositories.implementations;
using Greeniverse.src.utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GreeniverseTest.Tests.repositories
{

    [TestClass]
    public class UserRepositoryTest
    {
        private GreeniverseContext _context;
        private IUser _repository;

        [TestMethod]
        public void CreateTwoUsersInDBReturnTwoUsers()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse1")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            _repository.NewUser(
                new NewUserDTO(
                    "Thamy Cavalcanti", "thamy@email.com", "12345678", "AddressTest", 123456789, UserType.IndividualPerson)
            );

            _repository.NewUser(
                new NewUserDTO(
                    "Gaby Peres", "gaby@email.com", "87654321", "AdressTest", 987654321, UserType.Business)
            );

            Assert.AreEqual(2, _context.User.Count());
        }

        [TestMethod]
        public void GetUserByEmailReturnNotNull()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse2")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            _repository.NewUser(
                new NewUserDTO(
                    "RodrigoFranca", "rodrigo@email.com", "12345678", "TestAddress", 368536321, UserType.IndividualPerson)
            );

            var user = _repository.GetUserByEmailAsync("rodrigo@email.com");

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetUserByIdReturnNotNullAndUserName()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse3")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            _repository.NewUser(
                new NewUserDTO(
                    "Murilo Gama", "murilo@email.com", "38194093", "TestAddress", 582950126, UserType.Business)
            );

            var user = _repository.GetUserByIdAsync(1);

            Assert.IsNotNull(user);

            Assert.AreEqual("Murilo Gama", user.Name);
        }

        [TestMethod]
        public void UpdateUserReturnUserUpdated()
        {
            var opt = new DbContextOptionsBuilder<GreeniverseContext>()
                .UseInMemoryDatabase(databaseName: "db_greeniverse4")
                .Options;

            _context = new GreeniverseContext(opt);
            _repository = new UserRepository(_context);

            _repository.NewUser(
                new NewUserDTO(
                    "Uriel Pereira", "uriel@email.com", "48291038", "AddressTest", 520584015, UserType.IndividualPerson)
            );

            var old = _repository.GetUserByEmailAsync("uriel@email.com");
            _repository.UpdateUser(
                new UpdateUserDTO(
                        "Uriel Pereira", "urielpereira@email.com", "12345678", "AddressTest", 520584015, UserType.IndividualPerson)
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