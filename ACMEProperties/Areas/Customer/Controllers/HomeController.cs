using System.Diagnostics;
using ACMEProperties.DataAccess.Data.Repository.IRepository;
using ACMEProperties.Models;
using ACMEProperties.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ACMEProperties.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private HomeViewModel HomeViewM;

        public HomeController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeViewM = new HomeViewModel()
            {
                CategoryList = _unitOfWork.Category.GetAll(),
                PropertyList = _unitOfWork.Property.GetAll(includeProperties: "Rental")
            };

            return View(HomeViewM);
        }

        public IActionResult Details(int id)
        {
            var propertyFromDb =
                _unitOfWork.Property.GetFirstOrDefault(includeProperties: "Category,Rental", filter: p => p.Id == id);
            return View(propertyFromDb);
        }

       
    }
}
