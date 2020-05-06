using System;
using System.Collections.Generic;
using System.Text;
using ACMEProperties.Models;

namespace ACMEProperties.DataAccess.Data.Repository.IRepository
{
    public interface IRentalRepository
    {
        void Update(Rental rental);
    }
}
