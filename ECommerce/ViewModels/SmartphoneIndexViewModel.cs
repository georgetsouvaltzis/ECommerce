using ECommerce.Domain.Models;
using ECommerce.Infrastructure.ClassExtensions;
using ECommerce.Service.Models.Smartphone;

namespace ECommerce.ViewModels
{
    public class SmartphoneIndexViewModel
    {

        //Should check, IS IT A GOOD idea?
        public PaginatedList<SmartphoneModel> Smartphones { get; set; }

        public Manufacturer Manufacturer { get; set; }
        
        public SmartphoneFilter SmartphoneFilter { get; set; }

    }
}
