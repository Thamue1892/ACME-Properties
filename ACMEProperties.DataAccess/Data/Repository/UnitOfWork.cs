using System;
using System.Collections.Generic;
using System.Text;
using ACMEProperties.DataAccess.Data.Repository.IRepository;

namespace ACMEProperties.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Rental = new RentalRepository(_db);
            Property = new PropertyRepository(_db);
            User = new UserRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public IRentalRepository Rental { get; private set; }

        public IPropertyRepository Property { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
