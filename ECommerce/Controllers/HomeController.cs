using ECommerce.Infrastructure.ClassExtensions;
using ECommerce.Service.Abstract;
using ECommerce.Service.Models.Smartphone;
using ECommerce.Service.Models.Smartphone.Read;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmartphoneService _smartphoneService;

        public HomeController(ISmartphoneService smartphoneService)
        {
            _smartphoneService = smartphoneService;
        }

        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pageSize = 6)
        {
            var data = _smartphoneService.GetSmartphones(new ReadSmartphoneRequest
            {

            }).Data;
            return View(new SmartphoneIndexViewModel
            {
                // Should check if using SmartphoneModel is a good idea here
                Smartphones = PaginatedList<SmartphoneModel>.Create(
                    data,
                pageNumber,
                pageSize)
            });

        }

        [HttpPost]
        public IActionResult Index([FromForm] SmartphoneIndexViewModel smartphoneVM)
        {

            var otherValue = _smartphoneService.GetSmartphones(new ReadSmartphoneRequest
            {
                Manufacturer = new ManufacturerModel
                {
                    Name = smartphoneVM.Manufacturer?.Name,
                },
                Name = smartphoneVM.SmartphoneFilter.Name,
                PriceFrom = smartphoneVM.SmartphoneFilter.PriceFrom,
                PriceTo = smartphoneVM.SmartphoneFilter.PriceTo
            });

            return View(new SmartphoneIndexViewModel
            {
                Smartphones = PaginatedList<SmartphoneModel>.Create(otherValue.Data, 1, 300)

            });
        }
    }
}
