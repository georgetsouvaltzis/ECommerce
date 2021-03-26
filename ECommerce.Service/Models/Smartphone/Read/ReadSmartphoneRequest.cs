namespace ECommerce.Service.Models.Smartphone.Read
{
    public class ReadSmartphoneRequest
    {
        public ManufacturerModel Manufacturer { get; set; }
        public string Name { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}
