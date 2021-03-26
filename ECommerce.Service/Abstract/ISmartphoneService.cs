using ECommerce.Service.Infrastructure;
using ECommerce.Service.Models.Smartphone;
using ECommerce.Service.Models.Smartphone.Create;
using ECommerce.Service.Models.Smartphone.Delete;
using ECommerce.Service.Models.Smartphone.Details;
using ECommerce.Service.Models.Smartphone.Read;
using ECommerce.Service.Models.Smartphone.Update;
using System.Collections.Generic;

namespace ECommerce.Service.Abstract
{
    public interface ISmartphoneService
    {
        IResponse<ReadSmartphoneResponse,IEnumerable<SmartphoneModel>> GetSmartphones(ReadSmartphoneRequest request);

        IResponse<CreateSmartphoneResponse,int> Create(CreateSmartphoneRequest request);

        IResponse<DetailSmartphoneResponse, SmartphoneModel> Detail(DetailSmartphoneRequest request);

        IResponse<DeleteSmartphoneResponse, int> Delete(DeleteSmartphoneRequest request);

        IResponse<UpdateSmartphoneResponse, SmartphoneModel> Update(UpdateSmartphoneRequest request);
    }
}
