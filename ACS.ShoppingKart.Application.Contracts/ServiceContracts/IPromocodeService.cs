using ACS.ShoppingKart.Application.Contracts.Models;

namespace ACS.ShoppingKart.Application.Contracts.ServiceContracts
{
    public interface IPromocodeService
    {
        /// <summary>
        /// Applies promocode if it's valid
        /// </summary>
        void Apply(PromocodeRequest promocodeRequest);
    }
}
