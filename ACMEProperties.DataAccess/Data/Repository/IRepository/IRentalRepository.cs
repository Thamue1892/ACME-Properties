using System;
using System.Collections.Generic;
using System.Text;
using ACMEProperties.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACMEProperties.DataAccess.Data.Repository.IRepository
{
    public interface IRentalRepository:IRepository<Rental>
    {
        IEnumerable<SelectListItem> GetRentalListForDropDown();
        void Update(Rental rental);
    }
}
