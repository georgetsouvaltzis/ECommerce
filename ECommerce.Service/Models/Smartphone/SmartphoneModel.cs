
namespace ECommerce.Service.Models.Smartphone
{
    public class SmartphoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ManufacturerModel Manufacturer { get; set; }
        public int Size { get; set; }

        public decimal Weight { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public int Ram { get; set; }
        public string Processor { get; set; }
        public string OperatingSystem { get; set; }
        public decimal Price { get; set; }

    }
}
