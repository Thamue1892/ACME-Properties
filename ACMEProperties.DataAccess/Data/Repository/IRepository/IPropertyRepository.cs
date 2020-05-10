using System;
using System.Collections.Generic;
using System.Text;
using ACMEProperties.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ACMEProperties.DataAccess.Data.Repository.IRepository
{
    public interface IPropertyRepository:IRepository<Property>
    {
        void Update(Property property);
    }
}
