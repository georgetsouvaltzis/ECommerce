using ECommerce.Domain.DomainHelpers;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repository;
using ECommerce.Service.Abstract;
using ECommerce.Service.Infrastructure;
using ECommerce.Service.Models.Smartphone;
using ECommerce.Service.Models.Smartphone.Create;
using ECommerce.Service.Models.Smartphone.Delete;
using ECommerce.Service.Models.Smartphone.Details;
using ECommerce.Service.Models.Smartphone.Read;
using ECommerce.Service.Models.Smartphone.Update;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Service.Concrete
{
    public class SmartphoneService : ISmartphoneService
    {
        private readonly ISmartphoneRepository _smartphoneRepository;
        public SmartphoneService(ISmartphoneRepository repository)
        {
            _smartphoneRepository = repository;
        }


        public IResponse<CreateSmartphoneResponse, int> Create(CreateSmartphoneRequest request)
        {
            var smartphoneModel = request.SmartphoneModel;
            var manufacturerModel = request.ManufacturerModel;

            _smartphoneRepository.Create(new Smartphone(smartphoneModel.Name,
                new Manufacturer(manufacturerModel.Name)
                {
                    Id = manufacturerModel.Id
                },
                smartphoneModel.Size,
                smartphoneModel.Weight,
                new ScreenResolution(smartphoneModel.ScreenWidth, smartphoneModel.ScreenHeight),
                smartphoneModel.Ram,
                smartphoneModel.Processor,
                smartphoneModel.OperatingSystem,
                smartphoneModel.Price));

            return new CreateSmartphoneResponse
            {
                Data = smartphoneModel.Id,
                IsSuccess = true
            };

        }

        public IResponse<DeleteSmartphoneResponse, int> Delete(DeleteSmartphoneRequest request)
        => new DeleteSmartphoneResponse
        {
            IsSuccess = _smartphoneRepository.Delete(request.Id).IsSuccess
        };


        public IResponse<DetailSmartphoneResponse, SmartphoneModel> Detail(DetailSmartphoneRequest request)
        {
            var data = _smartphoneRepository.Detail(request.Id);

            if (data == null)
                return new DetailSmartphoneResponse
                {
                    IsSuccess = false
                };

            return new DetailSmartphoneResponse
            {
                Data = new SmartphoneModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    Manufacturer = new ManufacturerModel
                    {
                        Id = data.Manufacturer.Id,
                        Name = data.Manufacturer.Name,
                    },
                    OperatingSystem = data.OperatingSystem,
                    Price = data.Price,
                    Processor = data.Processor,
                    Ram = data.Ram,
                    ScreenHeight = data.ScreenHeight,
                    ScreenWidth = data.ScreenWidth,
                    Size = data.Size,
                    Weight = data.Weight
                },
                IsSuccess = true
            };
        }




        public IResponse<ReadSmartphoneResponse, IEnumerable<SmartphoneModel>> GetSmartphones(ReadSmartphoneRequest request)
        {
            var smartphones = _smartphoneRepository.GetAllSmartphones();

            if (!string.IsNullOrEmpty(request.Name))
                smartphones = smartphones.Where(x => x.Name.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.Manufacturer?.Name))
                smartphones = smartphones.Where(x => x.Manufacturer.Name.Contains(request.Manufacturer.Name));

            if (request.PriceFrom.HasValue)
                smartphones = smartphones.Where(x => x.Price >= request.PriceFrom.Value);

            if (request.PriceTo.HasValue)
                smartphones = smartphones.Where(x => x.Price <= request.PriceTo.Value);

            return new ReadSmartphoneResponse()
            {
                Data = smartphones
                .Select(x => new SmartphoneModel
                {
                    Name = x.Name,
                    Manufacturer = new ManufacturerModel() { Name = x.Manufacturer.Name },
                    OperatingSystem = x.OperatingSystem,
                    Price = x.Price,
                    Processor = x.Processor,
                    Ram = x.Ram,
                    ScreenHeight = x.ScreenHeight,
                    ScreenWidth = x.ScreenWidth,
                    Size = x.Size,
                    Weight = x.Weight
                })
                .ToList(),
                IsSuccess = true
            };
        }

        public IResponse<UpdateSmartphoneResponse, SmartphoneModel> Update(UpdateSmartphoneRequest request)
        {
            var result = _smartphoneRepository.Update(
                new Smartphone(request.SmartphoneModel.Name,
                    new Manufacturer(request.SmartphoneModel.Manufacturer.Name),
                    request.SmartphoneModel.Size,
                    request.SmartphoneModel.Weight,
                    new ScreenResolution(request.SmartphoneModel.ScreenWidth, request.SmartphoneModel.ScreenHeight),
                    request.SmartphoneModel.Ram,
                    request.SmartphoneModel.Processor,
                    request.SmartphoneModel.OperatingSystem,
                    request.SmartphoneModel.Price));

            if (result == null) return new UpdateSmartphoneResponse { IsSuccess = false };

            return new UpdateSmartphoneResponse()
            {
                Data = new SmartphoneModel
                {
                    Id = result.Id,
                    Manufacturer = new ManufacturerModel {
                        Id = result.Manufacturer.Id,
                        Name = result.Manufacturer.Name
                    },
                    Name = result.Name,
                    OperatingSystem = result.OperatingSystem,
                    Price = result.Price,
                    Processor = result.Processor,
                    Ram = result.Ram,
                    ScreenHeight = result.ScreenHeight,
                    ScreenWidth = result.ScreenWidth,
                    Size = result.Size,
                    Weight = result.Weight
                },
                IsSuccess = true
            };
        }

    }
}
