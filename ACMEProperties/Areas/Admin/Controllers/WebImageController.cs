using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMEProperties.DataAccess;
using ACMEProperties.Models;
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

        public IActionResult Upsert(int? id)
        {
            WebImages imageObj = new WebImages();
            if (id==null)
            {
                
            }
            else
            {
                imageObj = _db.WebImages.SingleOrDefault(i => i.Id == id);
                if (imageObj==null)
                {
                    return NotFound();
                }
            }

            return View(imageObj);
        }

        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new {data = _db.WebImages.ToList()});
        }

        #endregion
    }
}