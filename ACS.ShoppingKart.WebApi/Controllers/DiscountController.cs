using ACS.ShoppingKart.Application.Contracts.Models;
using ACS.ShoppingKart.Application.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACS.ShoppingKart.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;
        private readonly IPromocodeService _promocodeService;

        public DiscountController(ILogger<DiscountController> logger, IPromocodeService promocodeService)
        {
            _logger = logger;
            _promocodeService = promocodeService;
        }

        [HttpPost]
        [Route("Apply")]
        public IActionResult Apply(DiscountRequest discountRequest)
        {
            _logger.LogDebug($"Starting Discount/Apply endpoint method with promocode {discountRequest?.Promocode}");

            _promocodeService.Apply(discountRequest);

            return Ok();
        }
    }
}
