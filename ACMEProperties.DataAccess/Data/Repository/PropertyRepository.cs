using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACMEProperties.DataAccess.Data.Repository.IRepository;
using ACMEProperties.Models;

namespace ACMEProperties.DataAccess.Data.Repository
{
    class PropertyRepository:IPropertyRepository
    {
        private readonly ApplicationDbContext _db;

        public PropertyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Update(Property property)
        {
            var objFromDb = _db.Property.FirstOrDefault(p => p.Id == property.Id);

            objFromDb.Name = property.Name;
            objFromDb.Price = property.Price;
            objFromDb.Bathrooms = property.Bathrooms;
            objFromDb.NumberOfRooms = property.NumberOfRooms;
            objFromDb.ImageUrl = property.ImageUrl;
            objFromDb.LongDesc = property.LongDesc;
            objFromDb.CategoryId = property.CategoryId;

            _db.SaveChanges();
        }
    }
}
