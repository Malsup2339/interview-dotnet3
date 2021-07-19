using NUnit.Framework;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Repositories;
using GroceryStoreAPI.Controllers;
using System;
using System.Threading.Tasks;

namespace GroceryStoreAPITests
{
    [TestFixture]
    public class Tests
    {
        private CustomerDA _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new CustomerDA();
        }

        [Test]
        public async Task GetCustomersTest()
        {
            var response = await _repository.GetCustomersAsync();

            Assert.That(response.Success, Is.True);
            Assert.That(string.IsNullOrWhiteSpace(response.Message), Is.True);
        }

        [Test]
        [TestCase(1, "Bob")]
        [TestCase(2, "Mary")]
        [TestCase(3, "Joe")]
        public async Task GetCustomerByIdTest(int id, string expectedName)
        {
            var response = await _repository.GetCustomerByIdAsync(id);

            Assert.That(response.Success, Is.True);
            Assert.That(string.IsNullOrWhiteSpace(response.Message), Is.True);
            Assert.That(response.Customer.Id == id, Is.True);
            Assert.That(response.Customer.Name == expectedName, Is.True);
        }

        [Test]
        public async Task AddCustomerTest_ValidName_ReturnsSuccessful()
        {
            var response = await _repository.AddCustomerAsync("AnotherTest");

            Assert.That(response.Success, Is.True);
            Assert.That(string.IsNullOrWhiteSpace(response.Message), Is.True);
        }

        [Test]
        public async Task AddCustomerTest_InvalidName_Fails()
        {
            var response = await _repository.AddCustomerAsync("1234");

            Assert.That(response.Success, Is.False);
            Assert.That(string.IsNullOrWhiteSpace(response.Message), Is.False);
        }

        [Test]
        [TestCaseSource("_dummyDataUpdateCustomer")]
        public async Task UpdateCustomerTest(int idToUpdate, string name)
        {
            var response = await _repository.UpdateCustomerAsync(idToUpdate, name);

            Assert.That(response.Success, Is.True);
            Assert.That(string.IsNullOrWhiteSpace(response.Message), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            _repository = null;
        }

        private static readonly object[] _dummyDataUpdateCustomer =
        {
            new object[]  { 1, "UnitTest" },
            new object[]  { 1, "Bob" } ,
        };
    }
}