using ACS.ShoppingKart.Application.Contracts.Models;
using ACS.ShoppingKart.Application.Contracts.ServiceContracts;
using ACS.ShoppingKart.Application.Impl.Validations;
using ACS.ShoppingKart.Domain.Enums;
using ACS.ShoppingKart.Infrastructure.Contracts.RepositoryContracts;
using System;

namespace ACS.ShoppingKart.Application.Impl.Services
{
    public class PromocodeService : IPromocodeService
    {
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IProductRepository _productRepository;

        public PromocodeService(
            IPromocodeRepository promocodeRepository,
            IOrderRepository orderRepository,
            IOrderProductRepository orderProductRepository,
            IProductRepository productRepository)
        {
            _promocodeRepository = promocodeRepository;
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
        }

        public void Apply(PromocodeRequest promocodeRequest)
        {
            DiscountValidations.DiscountRequestValidation(promocodeRequest);

            var promocode = _promocodeRepository.GetById(promocodeRequest.Promocode);
            var order = _orderRepository.GetById(promocodeRequest.OrderId);

            switch (promocode.Type)
            {
                case PromocodeType.Total:

                    order.Discount = promocode.IsPercentage ? order.TotalPrice * promocode.DiscountValue : promocode.DiscountValue;
                    order.FinalPrice = CalculateFinalPrice(order.TotalPrice, order.Discount);
                    _orderRepository.UpdateOrder(order);

                    break;

                case PromocodeType.IndividualProduct:

                    var orderProductList = _orderProductRepository.GetByOrderId(promocodeRequest.OrderId);

                    foreach (var orderProduct in orderProductList)
                    {
                        var product = _productRepository.GetById(orderProduct.Product.Id);

                        if (product != null && promocode.DiscountKey == (int)product.Type)
                        {
                            order.Discount = promocode.IsPercentage ? order.TotalPrice * promocode.DiscountValue : promocode.DiscountValue;
                            order.FinalPrice = CalculateFinalPrice(order.TotalPrice, order.Discount);
                            _orderRepository.UpdateOrder(order);
                        }
                    }

                    break;

                case PromocodeType.ProductType:
                    throw new NotImplementedException();
                    break;

                case PromocodeType.CustomerType:
                    throw new NotImplementedException();
                    break;

                default:
                    throw new NotImplementedException();
                    break;
            }
        }

        private decimal CalculateFinalPrice(decimal totalPrice, decimal discount)
        {
            return totalPrice - discount;
        }
    }
}
