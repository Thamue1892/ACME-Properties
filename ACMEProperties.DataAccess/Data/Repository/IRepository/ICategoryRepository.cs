using ACMEProperties.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEProperties.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}
