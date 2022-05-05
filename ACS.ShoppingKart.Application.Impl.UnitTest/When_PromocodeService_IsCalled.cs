using ACS.ShoppingKart.Application.Contracts.Exceptions;
using ACS.ShoppingKart.Application.Contracts.Models;
using ACS.ShoppingKart.Application.Impl.Services;
using ACS.ShoppingKart.Domain.Entities;
using ACS.ShoppingKart.Domain.Enums;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            _promocodeRepositoryMock = new Mock<IPromocodeRepository>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderProductRepositoryMock = new Mock<IOrderProductRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        [TestMethod]
        public void Given_PromocodeRequest_When_Apply_IsCalled_With_PromocodeIdAndOrderId_Valid_Then_Ok()
        {
            // ARRANGE
            _promocodeRepositoryMock.Setup(m => m.GetById("TEST")).Returns(new Promocode
            {
                Id = "test",
                Type = PromocodeType.Total,
                DiscountValue = 10,
                IsPercentage = false
            });

            _orderRepositoryMock.Setup(m => m.GetById("TEST")).Returns(new Order
            {
                Id = "test",
                TotalPrice = 50
            });

            _sut = new PromocodeService(
                _promocodeRepositoryMock.Object,
                _orderRepositoryMock.Object,
                _orderProductRepositoryMock.Object,
                _productRepositoryMock.Object
                );

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

        [TestMethod]
        public void Given_PromocodeRequest_When_Apply_IsCalled_With_PromocodeId_NotValid_Then_Throw_PromocodeNotFoundException()
        {
            // ARRANGE
            _promocodeRepositoryMock.Setup(m => m.GetById("TEST")).Throws(new PromocodeNotFoundException("TEST"));

            _sut = new PromocodeService(
                _promocodeRepositoryMock.Object,
                _orderRepositoryMock.Object,
                _orderProductRepositoryMock.Object,
                _productRepositoryMock.Object
                );

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
            catch(PromocodeNotFoundException)
            {}
            catch (Exception)
            {
                // ASSERT
                Assert.Fail();
            }
        }
    }
}
