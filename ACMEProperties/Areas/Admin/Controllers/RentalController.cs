using ACMEProperties.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using ACMEProperties.Models;

namespace ACMEProperties.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Rental.GetAll() });
        }

        #endregion
    }
}