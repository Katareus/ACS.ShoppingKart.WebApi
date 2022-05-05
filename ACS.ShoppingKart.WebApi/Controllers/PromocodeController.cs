using ACS.ShoppingKart.Application.Contracts.Models;
using ACS.ShoppingKart.Application.Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACS.ShoppingKart.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromocodeController : ControllerBase
    {
        private readonly ILogger<PromocodeController> _logger;
        private readonly IPromocodeService _promocodeService;

        public PromocodeController(ILogger<PromocodeController> logger, IPromocodeService promocodeService)
        {
            _logger = logger;
            _promocodeService = promocodeService;
        }

        [HttpPost]
        [Route("Apply")]
        public IActionResult Apply(PromocodeRequest discountRequest)
        {
            _logger.LogDebug($"Starting Promocode/Apply endpoint method with promocode {discountRequest?.Promocode}");

            _promocodeService.Apply(discountRequest);

            return Ok();
        }
    }
}
