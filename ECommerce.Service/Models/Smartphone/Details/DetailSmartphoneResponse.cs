using ECommerce.Service.Infrastructure;

namespace ECommerce.Service.Models.Smartphone.Details
{
    public class DetailSmartphoneResponse : IResponse<DetailSmartphoneResponse, SmartphoneModel>
    {
        public bool IsSuccess { get; set; }

        public SmartphoneModel Data { get; set; }
    }
}
