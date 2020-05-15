using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMEProperties.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace ACMEProperties.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WebImageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WebImageController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new {data = _db.WebImages.ToList()});
        }

        #endregion
    }
}