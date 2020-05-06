using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEProperties.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }
        IRentalRepository Rental { get; }
        IPropertyRepository Property { get; }


        void Save();
    }
}
