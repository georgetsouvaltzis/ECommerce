using ECommerce.Service.Infrastructure;

namespace ECommerce.Service.Models.Smartphone.Update
{
    public class UpdateSmartphoneResponse : IResponse<UpdateSmartphoneResponse, SmartphoneModel>
    {
        public bool IsSuccess { get; set;  }

        public SmartphoneModel Data { get; set; }
    }
}
