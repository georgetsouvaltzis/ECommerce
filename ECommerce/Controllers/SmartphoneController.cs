using ECommerce.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class SmartphoneController : Controller
    {
        private readonly ISmartphoneRepository _smartphoneRepository;

        public SmartphoneController(ISmartphoneRepository smartphoneRepository)
        {
            _smartphoneRepository = smartphoneRepository;
        }
        public IActionResult Detail(int id) => View(_smartphoneRepository.Detail(id));
        
    }
}
