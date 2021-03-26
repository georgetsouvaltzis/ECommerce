using ECommerce.Service.Infrastructure;
using System.Collections.Generic;

namespace ECommerce.Service.Models.Smartphone.Read
{
    public class ReadSmartphoneResponse : IResponse<ReadSmartphoneResponse,IEnumerable<SmartphoneModel>>
    {
        public bool IsSuccess { get; set;  }
        public IEnumerable<SmartphoneModel> Data { get; set; }
    }
}
