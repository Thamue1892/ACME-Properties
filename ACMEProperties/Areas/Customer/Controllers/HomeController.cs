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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
