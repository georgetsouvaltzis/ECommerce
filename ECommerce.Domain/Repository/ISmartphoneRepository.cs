using ECommerce.Domain.DomainHelpers;
using ECommerce.Domain.Models;
using System.Linq;

namespace ECommerce.Domain.Repository
{
    public interface ISmartphoneRepository
    {

        IQueryable<Smartphone> GetAllSmartphones();

        Smartphone Detail(int id);

        int Create(Smartphone smartphone);

        // should be checked what to do with bool return type
        DeleteResponse Delete(int id);

        Smartphone Update(Smartphone smartphone);
    }

    public class DeleteResponse
    {
        public bool IsSuccess { get; set; }
    }
}
