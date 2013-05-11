using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniAmazon.Domain;
using MiniAmazon.Web.Controllers;
using Moq;

namespace MiniAmazon.Web.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void WhenCreatingNewInstanceForAccountController()
        {
            var mockRepository = new Mock<IRepository>();
            var mockMappingEngine = new Mock<IMappingEngine>();
            var accountController = new AccountController(mockRepository.Object, mockMappingEngine.Object);

            Assert.IsNotNull(accountController);
        }
    }
}
