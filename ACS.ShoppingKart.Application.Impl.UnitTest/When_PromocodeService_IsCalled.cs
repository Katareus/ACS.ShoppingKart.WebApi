using ACS.ShoppingKart.Application.Contracts.Models;
using ACS.ShoppingKart.Application.Impl.Services;
using ACS.ShoppingKart.Domain.Entities;
using ACS.ShoppingKart.Domain.Enums;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System;

namespace ACS.ShoppingKart.Application.Impl.UnitTest
{
    [TestClass]
    public class When_PromocodeService_IsCalled
    {

        private static PromocodeService _sut;

        private static MockFactory _mockFactory;
        private static Mock<IPromocodeRepository> _promocodeRepositoryMock;
        private static Mock<IOrderRepository> _orderRepositoryMock;
        private static Mock<IOrderProductRepository> _orderProductRepositoryMock;
        private static Mock<IProductRepository> _productRepositoryMock;

        [ClassInitialize]
        public static void InitClass(TestContext textContext)
        {
            _mockFactory = new MockFactory();

            _promocodeRepositoryMock = _mockFactory.CreateMock<IPromocodeRepository>();
            _orderRepositoryMock = _mockFactory.CreateMock<IOrderRepository>();
            _orderProductRepositoryMock = _mockFactory.CreateMock<IOrderProductRepository>();
            _productRepositoryMock = _mockFactory.CreateMock<IProductRepository>();

            _sut = new PromocodeService(
                _promocodeRepositoryMock.MockObject,
                _orderRepositoryMock.MockObject,
                _orderProductRepositoryMock.MockObject,
                _productRepositoryMock.MockObject
                );
        }

        [TestMethod]
        public void Given_PromocodeRequest_When_Apply_IsCalled_With_PromocodeTypeTotal_Then_Ok()
        {
            // ARRANGE
            _promocodeRepositoryMock.Expects
                .AtLeast(0)
                .Method(m => m.GetById(default(String)))
                .WithAnyArguments()
                .WillReturn(new Promocode
                {
                    Id = "test",
                    Type = PromocodeType.Total,
                    DiscountValue = 10,
                    IsPercentage = false
                });
            _orderRepositoryMock.Expects
                .AtLeast(0)
                .Method(m => m.GetById(default(String)))
                .WithAnyArguments()
                .WillReturn(new Order
                {
                    Id = "test",
                    TotalPrice = 50
                });

            var request = new PromocodeRequest
            {
                OrderId = "TEST",
                Promocode = "TEST"
            };

            // ACT
            try
            {
                _sut.Apply(request);
            }
            catch (Exception)
            {
                // ASSERT
                Assert.Fail();
            }
        }
    }
}
