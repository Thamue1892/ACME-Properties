using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMEProperties.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ACMEProperties.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new {data = _unitOfWork.Property.GetAll()});
        }

        #endregion
    }




}