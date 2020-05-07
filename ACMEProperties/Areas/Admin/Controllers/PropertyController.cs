using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ACMEProperties.DataAccess.Data.Repository.IRepository;
using ACMEProperties.Models;
using ACMEProperties.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ACMEProperties.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public PropertyViewModel PropertyViewModel { get; set; }

        public PropertyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            PropertyViewModel = new PropertyViewModel()
            {
                Property = new Models.Property(),
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                RentalList = _unitOfWork.Rental.GetRentalListForDropDown()
            };
            if (id != null)
            {
                PropertyViewModel.Property = _unitOfWork.Property.Get(id.GetValueOrDefault());
            }

            return View(PropertyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (PropertyViewModel.Property.Id == 0)
                {
                    //New Property
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\property");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    PropertyViewModel.Property.ImageUrl = @"\images\Propertys\" + fileName + extension;

                    _unitOfWork.Property.Add(PropertyViewModel.Property);
                }
                else
                {
                    //Edit Property
                    var propertyFromDb = _unitOfWork.Property.Get(PropertyViewModel.Property.Id);
                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\property");
                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, propertyFromDb.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }

                        PropertyViewModel.Property.ImageUrl = @"\images\property\" + fileName + extension_new;
                    }
                    else
                    {
                        PropertyViewModel.Property.ImageUrl = propertyFromDb.ImageUrl;
                    }

                    _unitOfWork.Property.Update(PropertyViewModel.Property);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(PropertyViewModel);
            }
        }




        #region API CALLS

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Property.GetAll(includeProperties: "Category,Rental") });
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var propertyFromDb = _unitOfWork.Property.Get(id);
        //}

        #endregion
    }




}