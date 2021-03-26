using ECommerce.Service.Infrastructure;

namespace ECommerce.Service.Models.Smartphone.Delete
{
    public class DeleteSmartphoneResponse: IResponse<DeleteSmartphoneResponse,int>
    {

        // OUT 200
        public bool IsSuccess { get; set; }
        public int Data { get; set; }
    }
}
