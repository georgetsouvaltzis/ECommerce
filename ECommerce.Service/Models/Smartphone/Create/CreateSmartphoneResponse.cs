using ECommerce.Service.Infrastructure;

namespace ECommerce.Service.Models.Smartphone.Create
{

    public class CreateSmartphoneResponse : IResponse<CreateSmartphoneResponse,int>
    {

        public int Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
