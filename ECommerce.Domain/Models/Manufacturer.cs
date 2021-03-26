using ECommerce.Domain.DomainHelpers;


namespace ECommerce.Domain.Models
{
    public class Manufacturer : Entity
    {
        public Manufacturer(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }

    }
}
