using ECommerce.Domain.Models;
using ECommerce.Domain.Repository;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerce.Infrastructure.RepositoryImplementations
{
    public class SmartphoneRepository : ISmartphoneRepository
    {
        private readonly ECommerceDbContext _db;
        public SmartphoneRepository(ECommerceDbContext context) => _db = context;

        public int Create(Smartphone smartphone)
        {
            Manufacturer manufacturerFromDb = null;
            
            if(smartphone.Manufacturer != null && smartphone.Manufacturer.Id != 0)
                manufacturerFromDb = _db.Manufacturers.FirstOrDefault(x => x.Id == smartphone.Manufacturer.Id);

            smartphone.Manufacturer = manufacturerFromDb ?? smartphone.Manufacturer;

            var data = _db.Smartphones.Add(smartphone);
            _db.SaveChanges();
            return data.Entity.Id;
        }

        public DeleteResponse Delete(int id)
        {

            var data = _db.Smartphones.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                _db.Smartphones.Remove(data);
                _db.SaveChanges();
                return new DeleteResponse { IsSuccess = true };
            }
            return new DeleteResponse { IsSuccess = false };

        }

        public Smartphone Detail(int id) => _db.Smartphones.Include(x => x.Manufacturer).FirstOrDefault(x => x.Id == id);

        public IQueryable<Smartphone> GetAllSmartphones() =>
            _db
            .Smartphones
            .Include(x => x.Manufacturer);


        public Smartphone Update(Smartphone smartphone)
        {
            var dbModel = _db.Smartphones.FirstOrDefault(x => x.Id == smartphone.Id);

            if (dbModel == null) return null;

            return dbModel;
        } 
    }
}
