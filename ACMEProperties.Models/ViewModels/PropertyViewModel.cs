using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEProperties.Models.ViewModels
{
    public class PropertyViewModel
    {
        public Property Property { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> RentalList { get; set; }
        
    }
}
