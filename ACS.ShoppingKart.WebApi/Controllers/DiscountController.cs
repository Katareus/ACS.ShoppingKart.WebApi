using ACS.ShoppingKart.Application.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ACS.ShoppingKart.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(ILogger<DiscountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Apply")]
        public IActionResult Apply(DiscountRequest discountRequest)
        {
            _logger.LogDebug($"Starting Discount/Apply endpoint method with promocode {discountRequest?.Promocode}");

            // Validation request
            if (string.IsNullOrEmpty(discountRequest?.Promocode))
            {
                throw new ArgumentException();
            }





            return Ok();
        }
    }
}
