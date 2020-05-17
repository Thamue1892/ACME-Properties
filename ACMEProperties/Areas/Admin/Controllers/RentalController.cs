using ACMEProperties.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using ACMEProperties.Models;
using Microsoft.AspNetCore.Authorization;

namespace ACMEProperties.Areas.Admin.Controllers
{
    [Authorize]
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


        public IActionResult Upsert(int? id)
        {
            Rental rental=new Rental();
            if (id==null)
            {
                return View(rental);
            }

            rental = _unitOfWork.Rental.Get(id.GetValueOrDefault());
            if (rental==null)
            {
                return NotFound();
            }

            return View(rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Rental rental)
        {
            if (ModelState.IsValid)
            {
                if (rental.Id==0)
                {
                    _unitOfWork.Rental.Add(rental);
                }
                else
                {
                    _unitOfWork.Rental.Update(rental);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(rental);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Rental.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Rental.Get(id);
            if (objFromDb==null)
            {
                return Json(new {success = false, message = "Error while deleting"});
            }
            _unitOfWork.Rental.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new {success = true, message = "Delete successful"});

        }

        #endregion
    }
}