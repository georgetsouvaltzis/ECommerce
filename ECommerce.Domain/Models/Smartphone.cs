using ECommerce.Domain.DomainHelpers;

namespace ECommerce.Domain.Models
{
    public class Smartphone : Entity
    {
        public Smartphone()
        {

        }
        public Smartphone(string name,
            Manufacturer manufacturer,
            int size,
            decimal weight,
            ScreenResolution screenResolution,
            int ram,
            string processor,
            string operatingSystem,
            decimal price)
        {
            Name = name;
            Manufacturer = manufacturer;
            Size = size;
            Weight = weight;
            ScreenWidth = screenResolution.Width;
            ScreenHeight = screenResolution.Height;
            Ram = ram;
            Processor = processor;
            OperatingSystem = operatingSystem;
            Price = price;

        }
        public string Name { get; private set; }


        // Should discuss this
        public Manufacturer Manufacturer { get; set; }
        public int Size { get; private set; }

        public decimal Weight { get; private set; }

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public int Ram { get; private set; }

        public string Processor { get; private set; }

        public string OperatingSystem { get; private set; }

        public decimal Price { get; private set; }
    }
}
