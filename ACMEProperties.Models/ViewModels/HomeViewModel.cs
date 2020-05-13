using System;
using System.Collections.Generic;
using System.Text;

namespace ACMEProperties.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<Property> PropertyList { get; set; }
    }
}
